using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAI : MonoBehaviour
{
    public Color ColorEstado;

    protected MachineStateAI maquinaDeEstados;
    protected DriverNavMeshAI controladorNavMesh;
    protected DriverVisionAI controladorVision;

    protected float SpeedNavMesh;

    protected virtual void Awake()
    {
        maquinaDeEstados = GetComponent<MachineStateAI>();
        controladorNavMesh = GetComponent<DriverNavMeshAI>();
        controladorVision = GetComponent<DriverVisionAI>();
    }

}
