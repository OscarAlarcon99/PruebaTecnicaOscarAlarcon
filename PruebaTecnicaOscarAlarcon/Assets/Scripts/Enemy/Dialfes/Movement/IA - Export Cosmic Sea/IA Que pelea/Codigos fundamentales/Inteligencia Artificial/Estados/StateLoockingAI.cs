using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLoockingAI : StateAI
{
    // Start is called before the first frame update
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
        Anim.SetBool("Alert", false);
        Anim.SetBool("Looking", true);
        Anim.SetBool("Ataque", false);
        Anim.SetBool("Muerte", false);
        Anim.SetBool("RecibiendoDaño", false);
        Anim.SetBool("Huyendo", false);
        controladorNavMesh.DetenerNavMeshAgent();
        tiempoBuscando = 0f;
    }

    void Update()
    {
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit) && maquinaDeEstados.SoyLuchador)
        {
            controladorNavMesh.perseguirObjectivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }

        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;

        if (tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla);
            return;
        }
    }
}
