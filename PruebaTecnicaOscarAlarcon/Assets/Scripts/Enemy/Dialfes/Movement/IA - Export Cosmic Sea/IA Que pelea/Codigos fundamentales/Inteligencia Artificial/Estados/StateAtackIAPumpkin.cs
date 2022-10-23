using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtackIAPumpkin : MonoBehaviour
{
    public float TiempoEntreAtaques = 2f;
    public bool PuedoAtacar;


    void OnEnable()
    {
        Anim.SetBool("Walk", false);
        Anim.SetBool("Ataque", true);

        SpeedNavMesh = 0f;
        controladorNavMesh.DetenerNavMeshAgent();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
