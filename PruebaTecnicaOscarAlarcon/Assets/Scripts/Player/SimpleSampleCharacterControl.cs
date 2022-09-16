using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleSampleCharacterControl : Singleton<SimpleSampleCharacterControl>
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
    public  CharacterInput characterPlayerInput; 
    /// <summary>
    /// Controlador de animaciones
    /// </summary>
    public Animator m_animator = null;
    /// <summary>
    /// Cuerpo Rigido del player
    /// </summary>
    [SerializeField] private Rigidbody m_rigidBody = null;
    /// <summary>
    /// Controlador de camara third person cinemachine
    /// </summary>
    [SerializeField] private CinemachineControllerCamera cinemachineCamera;
    /// <summary>
    /// objeto que referencia el horizonte del juego
    /// </summary>
    public GameObject ForwardObjectReference;
    /// <summary>
    /// Variable que almacena la anterior velocidad vertical
    /// </summary>
    private float m_currentV = 0;
    private float m_currentH2;

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
    public bool aimUse;
    public CannonController shooting;
    [SerializeField]
    private float m_moveSpeedV;
    [SerializeField]
    private float m_moveSpeedH;
    [SerializeField]
    private float m_turnSpeed;
    
    public Transform tr;
    private Vector3 oldMovementVelocity;
    [SerializeField] private float smoothingFactor;
    private void Awake()
    {
        base.Awake();
        //Inicializacion de variables si no han sido agregadas en el inspector
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
        Cursor.visible = false;
        tr = transform;
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
        if (!Player.Instance.IsActive)
            return;

        //if (Player.Instance.transform.position != Vector3.zero)
        //{
        //    HoldAnimations(gameObject.transform.position);
        //}
        //else
        //{
        //    HoldAnimations(Vector3.zero);
        //}
        cinemachineCamera.InputCamera();

        //Validacion para cuando entra input de salto
        if (!m_jumpInput && characterPlayerInput.IsJumpKeyPressed())
        {
            m_jumpInput = true;
        }

        //Validacion para cuando entra input de pausa

        if (characterPlayerInput.PauseKeyIsPressed())
        {
            ScenesManager.Instance.Pause();
        }

        //Lectura de input
        characterPlayerInput.GetInput();
    }

    private void FixedUpdate()
    {
        if (!Player.Instance.IsActive)
            return;
        
        //DirectUpdate();
        //TankUpdate();

        if (!aimUse)
        {
            //Actualizacion de direccion de momiviento
            TankUpdate();
            //DirectUpdate();
        }
        else
        {
            TankUpdate();
        }

        #region Control de Salto

        // envio a controlador de animacion del bool si toca el piso 
        m_animator.SetBool("Grounded", m_isGrounded);

        //Actualizacion de bool de aire
        m_wasGrounded = m_isGrounded;

       // ajuste de variable de input a falso 
        m_jumpInput = false;

        #endregion
    }

    private void TankUpdate()
    {
        float h = characterPlayerInput.GetHorizontalCameraInput();
        float  h2 = characterPlayerInput.GetHorizontalMovementInput();
        float v = characterPlayerInput.GetVerticalMovementInput();

        
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);
        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH2 = Mathf.Lerp(m_currentH2, h2, Time.deltaTime * m_interpolation);

        transform.position += tr.forward * m_currentV * m_moveSpeedV * Time.deltaTime;
        transform.position += tr.right * m_currentH2 * m_moveSpeedH * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);


        m_animator.SetFloat("MoveSpeedV", Mathf.Lerp(v, 1.2f ,Time.deltaTime) , 0.3f,Time.deltaTime);
        m_animator.SetFloat("MoveSpeedH", Mathf.Lerp(h2, 1.2f, Time.deltaTime), 0.3f, Time.deltaTime);
        m_animator.SetBool("Aim", aimUse);

        JumpingAndLanding();
    }

    public void HoldAnimations(Vector3 _velocity)
    {
        Debug.Log(_velocity);

        //Split up velocity;
        Vector3 _horizontalVelocity = VectorMath.RemoveDotVector(_velocity, tr.up);
        Vector3 _verticalVelocity = _velocity - _horizontalVelocity;

        //Smooth horizontal velocity for fluid animation;
        _horizontalVelocity = Vector3.Lerp(oldMovementVelocity, _horizontalVelocity, smoothingFactor);
        oldMovementVelocity = _horizontalVelocity;

        m_animator.SetFloat("MoveSpeedV", _verticalVelocity.magnitude * VectorMath.GetDotProduct(_verticalVelocity.normalized, tr.up));
        m_animator.SetFloat("MoveSpeedH", _horizontalVelocity.magnitude);
        m_animator.SetBool("Aim", aimUse);
    }

    public void SendAnimationReaction(int index)
    {
        if (index == 0)
        {
            m_animator.SetTrigger("Damage");
        }

        if (index == 1)
        {
            m_animator.SetTrigger("Attack");           
        }

        if (index == 2)
        {
            m_animator.SetTrigger("Dead");
        }
    }

    public void CallAim(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector3 test = Camera.main.transform.localEulerAngles;
            transform.localEulerAngles = new Vector3(0f, test.y, 0);
            shooting.firstPosition = shooting.transform.localEulerAngles;
            aimUse = true;
        }

        if (context.performed)
        {
            aimUse = true;
        }

        if (context.canceled)
        {
            aimUse = false;
            SendAnimationReaction(1);
        }

        if (Player.Instance.Ammo > 0 && aimUse)
        {
            shooting.line.enabled = true;
        }
        else
        {
            shooting.transform.localEulerAngles = shooting.firstPosition;
            shooting.line.enabled = false;
        }
    }


    /// <summary>
    /// Funcion encargada de calcular y aplicar nueva direccion al jugador
    /// </summary>
    private void DirectUpdate()
    {
        //Lectura de input vertical
        float v = characterPlayerInput.GetVerticalMovementInput();
        //Lectura de input horizontal
        float h = characterPlayerInput.GetHorizontalMovementInput();

        //referencia de posicion de maincamera
        Transform camera = Camera.main.transform;

        // Interpolacion en la variacion  de la velocidad capatada por el input 
        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        // aplicar movimiento apartir de la camara 
        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

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
            m_animator.SetFloat("MoveSpeedV", direction.magnitude);
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
