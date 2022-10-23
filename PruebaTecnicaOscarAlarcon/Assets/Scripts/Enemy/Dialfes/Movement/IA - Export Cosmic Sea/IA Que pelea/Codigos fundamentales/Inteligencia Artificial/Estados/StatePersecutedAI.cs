using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StatePersecutedAI : StateAI
{
    public Animator Anim;
    protected override void Awake()
    {
        base.Awake();
        Anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        Anim.SetBool("Atack", true);
        Anim.SetBool("Walk", false);
        Anim.SetBool("Alert", false);
        Anim.SetBool("Looking", false);
        Anim.SetBool("Ataque", false);
        Anim.SetBool("Muerte", false);
        Anim.SetBool("RecibiendoDaño", false);
        Anim.SetBool("Huyendo", false);

    }

    void Update()
    {
        SpeedNavMesh = 0.7f;
        RaycastHit hit;
        if (!controladorVision.PuedeVerAlJugador(out hit, true))
        {

            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }
        else
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
        }
        if (maquinaDeEstados.PuedoAtacar)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAtaque);
        }

        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
    }

}
