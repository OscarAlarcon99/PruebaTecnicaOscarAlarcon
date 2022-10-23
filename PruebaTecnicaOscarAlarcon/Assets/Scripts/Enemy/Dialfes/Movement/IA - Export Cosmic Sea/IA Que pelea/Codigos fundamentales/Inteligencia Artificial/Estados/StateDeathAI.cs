using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDeathAI : StateAI
{
    // Start is called before the first frame update
    public float duracionBusqueda = 4f;

    public Animator Anim;

    private float tiempoMuriendo;

    protected override void Awake()
    {
        base.Awake();
        Anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        Anim.SetBool("Atack", false);
        Anim.SetBool("Walk", false);
        Anim.SetBool("Alert", false);
        Anim.SetBool("Looking", false);
        Anim.SetBool("Ataque", false);
        Anim.SetBool("Muerte", false);
        Anim.SetBool("RecibiendoDaño", false);
        Anim.SetBool("Huyendo", false);
        Anim.SetBool("Muerte", true);
        controladorNavMesh.DetenerNavMeshAgent();
        tiempoMuriendo = 0f;
        SpeedNavMesh = 0f;
    }

    void Update()
    {
      
        tiempoMuriendo += Time.deltaTime;
        if (tiempoMuriendo >= duracionBusqueda)
        {
            Invoke("Muerte", 1);
        }
    }
    void Muerte()
    {
        //Animacion de que el personaje se hunde en el suelo 
        //despues de 3 segundos desaparece de la escena para no generar peso innecesario.
    }
}
