using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineStateAI : MonoBehaviour
{
    public StateAI EstadoPatrulla;
    public StateAI EstadoSaludando;
    public StateAI EstadoPersecucion;
    public StateAI EstadoAlerta;
    public StateAI EstadoBuscando;
    public StateAI EstadoAtaque;
    public StateAI EstadoHuyendo;
    //public StateAI EstateRecibirDaño;
    public StateAI EstadoMuerte;

    public StateAI EstadoInicial;

    public bool PuedoAtacar;
    public bool SigoAtacando;
    public bool ModoAlerta;
    public bool Daño;
    public bool SoyNpc;
    public bool SoyLuchador;
    public bool EstoyMuerto;

    public enum TypeIA {Npc,Luchador};

    public TypeIA TypeActual;

    public int N_Type;

    public bool TengoArma;

    public MeshRenderer MeshRendererIndicador;

    private StateAI estadoActual;

    // Start is called before the first frame update
    void Start()
    {
        ActivarEstado(EstadoInicial);
        StartSeleccion();
        StartType();

    }
    void StartSeleccion()
    {
        switch (TypeActual)
        {
            case TypeIA.Npc: N_Type = 0;
                break;
            case TypeIA.Luchador : N_Type = 1;
                break;
            default:
                break;
        }
    }
    void StartType()
    {
        if (N_Type == 0)
        {
            SoyAldeano();
        }
        if (N_Type == 1)
        {
            SoyCerdo();
        }
    }

    public void ActivarEstado(StateAI nuevoEstado)
    {
        if (estadoActual != null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;

        MeshRendererIndicador.material.color = estadoActual.ColorEstado;
    }
    public void SoyAldeano()
    {
        SoyNpc = true;
    }
    public void SoyCerdo()
    {
        SoyLuchador = true;
    }


}