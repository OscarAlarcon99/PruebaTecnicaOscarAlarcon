﻿using System.Collections.Generic;
using UnityEngine;

public class SimpleSampleCharacterControl : MonoBehaviour
{
    /// <summary>
    /// Variable que almacena la velocidad del movimiento
    /// </summary>
    [SerializeField] private float moveSpeed = 2;
    /// <summary>
    /// Variable que almacena la fuerza del salto
    /// </summary>
    [SerializeField] private float m_jumpForce = 4;
    /// <summary>
    /// Controlador de animaciones
    /// </summary>
    [SerializeField]
    private CharacterInput characterPlayer; 
    /// <summary>
    /// Controlador de animaciones
    /// </summary>
    [SerializeField] private Animator m_animator = null;
    /// <summary>
    /// Cuerpo Rigido del player
    /// </summary>
    [SerializeField] private Rigidbody m_rigidBody = null;
    /// <summary>
    /// objeto que referencia el horizonte del juego
    /// </summary>
    public GameObject ForwardObjectReference;
    /// <summary>
    /// Variable que almacena la anterior velocidad vertical
    /// </summary>
    private float m_currentV = 0;
    /// <summary>
    /// Variable que almacena la anterior velocidad horizontal
    /// </summary>
    private float m_currentH = 0;
    /// <summary>
    /// Variable que almacena la lecutura de la interpolacion al caminar
    /// </summary>
    private readonly float m_interpolation = 10;

    /// <summary>
    /// Variable que almacena la lecutura de la Velocidad caminando
    /// </summary>
    private readonly float m_walkScale = 0.33f;
    /// <summary>
    /// Variable que almacena vector por donde nos hemos movido
    /// </summary>
    [SerializeField]
    private Vector3 m_currentDirection = Vector3.zero;
    /// <summary>
    /// Variable que almacena el tiempo de caida del salto
    /// </summary>
    [SerializeField]
    private float m_jumpTimeStamp = 0;
    /// <summary>
    /// Variable que almacena la variacion minima del intervalo de salto
    /// </summary>
    [SerializeField]
    private float m_minJumpInterval = 0.25f;
    /// <summary>
    /// Variable que almacena bool de si se toca el iput de salto   
    /// </summary>
    [SerializeField]
    private bool m_jumpInput = false;
    /// <summary>
    /// Variable que almacena bool de si el player esta tocando el suelo
    /// </summary>
    [SerializeField]
    private bool m_isGrounded;
    /// <summary>
    /// Variable que almacena bool de si el player esta en el aire
    /// </summary>
    [SerializeField]
    private bool m_wasGrounded;
    /// <summary>
    /// Listado que almacena objetos donde toco suelo
    /// </summary>
    private List<Collider> m_collisions = new List<Collider>();

    private void Awake()
    {
        //Inicializacion de variables si no han sido agregadas en el inspector
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        #region Contacto entrada con el suelo

        //contacto donde ocurre la entrada de la colisión.
        ContactPoint[] contactPoints = collision.contacts;

        // for para validar todos los contactos
        for (int i = 0; i < contactPoints.Length; i++)
        {
            //validacion de si los vectores de colision son perpendiculares al player.
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                //validacion de que no exista anteriormente esta colision
                if (!m_collisions.Contains(collision.collider))
                {
                    // agregar colision 
                    m_collisions.Add(collision.collider);
                }
                
                // esta tocando el piso 
                m_isGrounded = true;
            }
        }

        #endregion
    }

    private void OnCollisionStay(Collision collision)
    {
        #region Contacto con el suelo

        //contacto donde ocurre la colisión.
        ContactPoint[] contactPoints = collision.contacts;

        //validacion de si toca superficie normal
        bool validSurfaceNormal = false;

        // for para validar todos los contactos
        for (int i = 0; i < contactPoints.Length; i++)
        {
            //validacion de si los vectores de colision son perpendiculares al player.
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        // validacion de si aun sigue en el piso 
        if (validSurfaceNormal)
        {
            //sigue en el piso
            m_isGrounded = true;

            //validacion de que no exista anteriormente esta colision
            if (!m_collisions.Contains(collision.collider))
            {
                // agregar colision 
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            //validacion de que no exista anteriormente esta colision
            if (m_collisions.Contains(collision.collider))
            {
                // quitar colision 
                m_collisions.Remove(collision.collider);
            }
            
            //validar si no hay ningun contacto
            if (m_collisions.Count == 0) 
            {
                //ya no esta en el piso
                m_isGrounded = false; 
            }
        }

        #endregion
    }

    private void OnCollisionExit(Collision collision)
    {
        #region Contacto salida con el suelo
        
        //validacion de que ya no sigue la anterior colision
        if (m_collisions.Contains(collision.collider))
        {
            //quitar la anterior colision
            m_collisions.Remove(collision.collider);
        }
        
        //validar si no hay ningun contacto
        if (m_collisions.Count == 0) 
        { 
            //ya no esta en el piso
            m_isGrounded = false;
        }

        #endregion
    }

    private void Update()
    {
        //Validacion para cuando entra input de salto
        if (!m_jumpInput && characterPlayer.IsJumpKeyPressed())
        {
            m_jumpInput = true;
        }
        
        //Lectura de input
        characterPlayer.GetInput();
    }

    private void FixedUpdate()
    {
        //Actualizacion de direccion de momiviento
        DirectUpdate();

        #region Control de Salto

        // envio a controlador de animacion del bool si toca el piso 
        m_animator.SetBool("Grounded", m_isGrounded);

        //Actualizacion de bool de aire
        m_wasGrounded = m_isGrounded;

       // ajuste de variable de input a falso 
        m_jumpInput = false;

        #endregion
    }

    /// <summary>
    /// Funcion encargada de calcular y aplicar nueva direccion al jugador
    /// </summary>
    private void DirectUpdate()
    {
        //Lectura de input vertical
        float v = characterPlayer.GetVerticalMovementInput();
        //Lectura de input horizontal
        float h = characterPlayer.GetHorizontalMovementInput();

        //referencia de posicion de maincamera
        Transform camera = Camera.main.transform;

        // Validacion de lectura de input mientras camina
        if (characterPlayer.IsActionPressed())
        {
            Debug.Log("sss");

            // multiplicacion por escala de velocidad caminando 
            v *= m_walkScale;
            h *= m_walkScale;
        }

        // Interpolacion en la variacion  de la velocidad capatada por el input 
        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        // aplicar movimiento apartir de la camara 
        Vector3 direction = ForwardObjectReference.transform.forward * m_currentV + ForwardObjectReference.transform.right * m_currentH;

        float directionLength = direction.magnitude;
        
        direction.y = 0;
        
        direction = direction.normalized * directionLength;

        //si se mueve 
        if (direction != Vector3.zero)
        {
            //Interpolacion del giro 
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            //aplicar rotacion al player
            transform.rotation = Quaternion.LookRotation(m_currentDirection);

            //aplicar movimiento al player
            transform.position += m_currentDirection * moveSpeed * Time.deltaTime;
            
            //envio de velocidad del movimiento a controlador de animaciones
            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        // llamada del salto y caida 
        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        //bool que valida si el salto fue afectuado para inicial conteo de caida
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        //validacion despues de precionar input de salto
        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            //asignacion de tiempo de caida
            m_jumpTimeStamp = Time.time;

            //agregar fuerza de salto
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        // validacion de que esta en el aire 
        if (!m_wasGrounded && m_isGrounded)
        {
            // activar trigger de caida
            m_animator.SetTrigger("Land");
        }

        // validacion de que despego del suelo
        if (!m_isGrounded && m_wasGrounded)
        {
            // activar trigger de salto
            m_animator.SetTrigger("Jump");
        }
    }
}
