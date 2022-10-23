using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAlertAI : StateAI
{
    public float velocidadGiroBusqueda = 120f;
    public float duracionBusqueda = 4f;

    public Animator Anim;

    private float tiempoBuscando;

    protected override void Awake()
    {
        base.Awake();
        Anim = GetComponent<Animator>();

    }

    void OnEnable()
    {
        Anim.SetBool("Atack", false);
        Anim.SetBool("Walk", false);
        Anim.SetBool("Alert", true);
        Anim.SetBool("Looking", false);
        Anim.SetBool("Ataque", false);
        Anim.SetBool("Muerte", false);
        Anim.SetBool("RecibiendoDaño", false);
        Anim.SetBool("Huyendo", false);
        //controladorNavMesh.DetenerNavMeshAgent();
        tiempoBuscando = 0f;
    }

    void Update()
    {
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit))
        {
            controladorNavMesh.perseguirObjectivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }
        if (controladorNavMesh.HemosLlegado())
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoBuscando);
        }


        // transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);
        //tiempoBuscando += Time.deltaTime;
        // if (tiempoBuscando >= duracionBusqueda)
        //{
        //   maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla);
        //  return;
        //}
        controladorNavMesh.EnemigoFueraDeSigilo();
    }
}
