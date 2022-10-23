using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtackAI : StateAI
{
    // Start is called before the first frame update
    public float TiempoEntreAtaques = 2f;
    public bool PuedoAtacar;

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
        Anim.SetBool("Looking", false);
        Anim.SetBool("Ataque", true);
        Anim.SetBool("Muerte", false);
        Anim.SetBool("RecibiendoDaño", false);
        Anim.SetBool("Huyendo", false);

        SpeedNavMesh = 0f;
        controladorNavMesh.DetenerNavMeshAgent();
    }

    void Update()
    {
        RaycastHit hit;
        if (!controladorVision.PuedeVerAlJugador(out hit, true))
        {

            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }
        if (!maquinaDeEstados.PuedoAtacar) //Variable en la maquina de estados
        {
            controladorNavMesh.perseguirObjectivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }
        if (maquinaDeEstados.SigoAtacando == true)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAtaque);
            return;
        }


    }
}
