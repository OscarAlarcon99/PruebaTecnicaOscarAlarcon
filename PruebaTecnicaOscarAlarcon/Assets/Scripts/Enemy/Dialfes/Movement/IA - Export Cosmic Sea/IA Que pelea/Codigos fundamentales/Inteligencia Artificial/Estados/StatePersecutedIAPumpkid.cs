using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StatePersecutedIAPumpkid : MonoBehaviour
{

    void Update()
    {
        SpeedNavMesh = 0.7f;
        maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
        if (maquinaDeEstados.PuedoAtacar)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAtaque);
        }
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
    
    }
    public void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player") && enabled) // Si el player entra el collider y no esta en modo alerta
            {
                Peligroso();
            }
    }
}
