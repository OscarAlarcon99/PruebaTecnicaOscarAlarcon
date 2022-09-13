using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Singleton<EnemyBoss>
{
    public Animator anim;
    [SerializeField]
    public EnemyHealt healt;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Vector3 aimOffset;
    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    State currentState;
    [SerializeField] 
    Transform rotator;
    [SerializeField]
    Transform ghostRotator;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    Transform gunBarrel;


    public Quaternion DefaultRotation { get; set; }
    public Transform Target { get; set; }
    public Transform Rotator { get => rotator; set => rotator = value; }
    public Vector3 AimOffset { get => aimOffset; set => aimOffset = value; }
    public Transform GhostRotator { get => ghostRotator; set => ghostRotator = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public Transform GunBarrel { get => gunBarrel; set => gunBarrel = value; }

    void Start()
    {
        DefaultRotation = rotator.rotation;
        ChangeState(new IdleState());
    }

    void Update()
    {
        currentState.Update();
    }

    public bool CanSeeTarget(Vector3 direction, Vector3 origin, string tag)
    {
        RaycastHit hit;

        if (Physics.Raycast(origin,direction, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawLine(origin, direction, Color.red);

            if (hit.collider.CompareTag(tag))
            {
                return true;
            }
        }
        
        return false;
    }

    public void ChangeState(State newState)
    {
        if (newState != null)
        {
            newState.Exit();
        }
        
        currentState = newState;
        newState.Enter(this);
    }

    public void Die()
    {
        anim.SetBool("Dead", true);
    }

    public void Damage()
    {
        anim.SetTrigger("Damage");
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OntriggerExit(other); 
    }
}
