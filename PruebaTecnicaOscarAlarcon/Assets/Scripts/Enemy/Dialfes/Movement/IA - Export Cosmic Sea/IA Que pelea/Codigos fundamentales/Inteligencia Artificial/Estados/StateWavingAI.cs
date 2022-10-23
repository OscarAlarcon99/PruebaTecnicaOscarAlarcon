using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWavingAI : StateAI
{
    public float duracionSaludo = 4f;

    public Animator Anim;

    private float tiempoSaludando;

    protected override void Awake()
    {
        base.Awake();
        Anim = GetComponent<Animator>();
        
       
    }
    void OnEnable()
    {
        Anim.SetBool("Walk", false);
        Anim.SetBool("Alert", false);
        Anim.SetBool("RecibiendoDaño", false);
        Anim.SetBool("Huyendo", false);
        Anim.SetBool("Saludando", true);
        controladorNavMesh.DetenerNavMeshAgent();
        SpeedNavMesh = 0;
        tiempoSaludando = 0f;

    }


    // Update is called once per frame
    void Update()
    {
        tiempoSaludando += Time.deltaTime;

        if (tiempoSaludando >= duracionSaludo)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla);
            return;
        }
    }
}
