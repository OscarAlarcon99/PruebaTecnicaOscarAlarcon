using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DriverNavMeshAI : MonoBehaviour
{
    public Transform sonidoObjetivo;
    public Transform perseguirObjectivo;
    public Transform HuirObjetivo;
    [SerializeField]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    // Start is called before the first frame update
    public void ActualizarPuntoDestinoNavMeshAgent(Vector3 puntoDestino)
    {
        navMeshAgent.destination = puntoDestino;
        navMeshAgent.Resume();
    }

    public void ActualizarPuntoDestinoNavMeshAgent()
    {
        ActualizarPuntoDestinoNavMeshAgent(perseguirObjectivo.position);
    }
    public void EnemigoFueraDeSigilo()
    {
        ActualizarPuntoDestinoNavMeshAgent(sonidoObjetivo.position);
    }
    public void HuyendoDelPeligro()
    {
        ActualizarPuntoDestinoNavMeshAgent(HuirObjetivo.position);
    }


    public void DetenerNavMeshAgent()
    {
        navMeshAgent.Stop();
    }
    public bool HemosLlegado()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }

}
