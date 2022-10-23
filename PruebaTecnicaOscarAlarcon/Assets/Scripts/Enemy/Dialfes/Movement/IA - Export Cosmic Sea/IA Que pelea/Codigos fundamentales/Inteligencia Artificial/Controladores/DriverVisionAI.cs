using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverVisionAI : MonoBehaviour
{

    public Transform Ojos;
    public float rangoVision = 20f;
    public Vector3 offset = new Vector3(0f, 0.75f, 0f);

    private DriverNavMeshAI controladorNavMesh;

    void Awake()
    {
        controladorNavMesh = GetComponent<DriverNavMeshAI>();
    }

    public bool PuedeVerAlJugador(out RaycastHit hit, bool mirarHaciaElJugador = false)
    {
        Vector3 vectorDireccion;
        if (mirarHaciaElJugador)
        {
            vectorDireccion = (controladorNavMesh.perseguirObjectivo.position + offset) - Ojos.position;
        }
        else
        {
            vectorDireccion = Ojos.forward;
        }

        return Physics.Raycast(Ojos.position, vectorDireccion, out hit, rangoVision) && hit.collider.CompareTag("Player");
    }
    // Enemigo en rango de vision
}
