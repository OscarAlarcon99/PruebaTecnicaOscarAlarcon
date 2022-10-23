using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineStatepumpkin : MonoBehaviour
{
    public StateAI EstadoPersecucion;
    public StateAI EstadoAtaque;
    public StateAI EstadoMuerte;

    public StateAI EstadoInicial;

    public bool PuedoAtacar;
    public bool SigoAtacando;
    public bool EstoyMuerto;

    public MeshRenderer MeshRendererIndicador;

    private StateAI estadoActual;
    // Start is called before the first frame update
    void Start()
    {
        ActivarEstado(EstadoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivarEstado(StateAI nuevoEstado)
    {
        if (estadoActual != null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;

        MeshRendererIndicador.material.color = estadoActual.ColorEstado;
    }

}
