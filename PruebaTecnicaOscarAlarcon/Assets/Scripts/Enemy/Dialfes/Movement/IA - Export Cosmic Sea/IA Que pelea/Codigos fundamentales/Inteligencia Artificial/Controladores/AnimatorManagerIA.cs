using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManagerIA : MonoBehaviour
{
    public StateAI EstadoInicial;
    //private StateAI estadoActual;

    public enum estadoActual { Patrulla, Persecusion, Alerta, Buscando, Ataque, Huyendo, Desenfundando, Guardando, Muerte};

    public estadoActual Actual;
    public int N_Anim;
    public int N_Type;


    // Start is called before the first frame update
    void Start()
    {
        ActivarEstado(EstadoInicial);
        StartSeleccion();
        StartType();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartSeleccion()
    {
        switch (N_Anim)
        {
            case 0:
                N_Type = 0;
                break;
            case 1:
                N_Type = 1;
                break;
            case 2:
                N_Type = 2;
                break;
            case 3:
                N_Anim = 3;
                break;
            case 4:
                N_Type = 4;
                break;
            case 5:
                N_Type = 5;
                break;
            case 6:
                N_Type = 6;
                break;
            case 7:
                N_Anim = 7;
                break;
            case 8:
                N_Type = 8;
                break;
            case 9:
                N_Type = 9;
                break;
            case 10:
                N_Type = 10;
                break;
            default:
                break;
        }
    }
    void StartType()
    {
        if (N_Type == 0)
        {
           
        }
        if (N_Type == 1)
        {
           
        }
    }

    public void ActivarEstado(StateAI nuevoEstado)
    {
        //if (estadoActual != null) estadoActual.enabled = false;
        //estadoActual = nuevoEstado;
        //estadoActual.enabled = true;

      //  MeshRendererIndicador.material.color = estadoActual.ColorEstado;
    }
    public void AnimPatrulla ()
    {
        
    }
    public void AnimPersecusion()
    {

    }
    public void AnimaBuscando()
    {

    }
    public void AnimAtacando()
    {

    }
    public void AnimAlerta()
    {
        
    }
    public void AnimHuyendo()
    {

    }
    public void AnimSaludando()
    {

    }
    public void AnimMuerte()
    {

    }
}
