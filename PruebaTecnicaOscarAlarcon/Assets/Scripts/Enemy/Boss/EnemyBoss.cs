using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Singleton<EnemyBoss>
{
    public Animator anim;
    [SerializeField]
    public EnemyHealt healt;
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
    [SerializeField]
    bool isActive;
    [SerializeField]
    float distanceBetweenTarget;
    [SerializeField]
    GameObject StartPositon;

    private float minDistanceTime;
    private float midleDistanceTime;
    private float longDistanceTime;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float midleDistance;
    [SerializeField]
    private float longDistance;
    [SerializeField]
    private float speedMoveZ;

    public Quaternion DefaultRotation { get; set; }
    public Transform Target { get; set; }
    public Transform Rotator { get => rotator; set => rotator = value; }
    public Vector3 AimOffset { get => aimOffset; set => aimOffset = value; }
    public Transform GhostRotator { get => ghostRotator; set => ghostRotator = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public Transform GunBarrel { get => gunBarrel; set => gunBarrel = value; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public float DistanceBetweenTarget { get => distanceBetweenTarget; set => distanceBetweenTarget = value; }

    void Start()
    {
        DefaultRotation = rotator.rotation;
        ChangeState(new IdleState());
    }

    void Update()
    {
        if (isActive)
        {
            currentState.Update();
            ChangeHeight();
            DistanceBetweenTarget = Vector3.Distance(StartPositon.transform.position, Player.Instance.transform.position);
        }
        else
        {
            Desactivate();
        }
    }
    public void Desactivate()
    {
        anim.SetFloat("VelAttack", 0f);
        anim.SetBool("Shoot", false);
        ChangeState(new IdleState());
    }

    public void CalculateDistanceBetweenTarget()
    {
        if (Target != null)
        {
            if (distanceBetweenTarget < 6)
            {
                ChangeFiringRate(minDistanceTime);
            }
            else if (distanceBetweenTarget < 12)
            {
                ChangeFiringRate(midleDistanceTime);
            }
            else
            {
                ChangeFiringRate(longDistanceTime);
            }
        }
    }

    void ChangeFiringRate(float value)
    {
        anim.SetFloat("VelAttack", value);
    }

    void ChangeHeight()
    {
        if (Target != null)
        {
            if (distanceBetweenTarget < 18)
            {
                transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, new Vector3(StartPositon.transform.position.x, minDistance, StartPositon.transform.position.z), speedMoveZ * Time.deltaTime), transform.position.z);
            }
            else if (distanceBetweenTarget < 25)
            {
                transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, new Vector3(StartPositon.transform.position.x, midleDistance, StartPositon.transform.position.z), speedMoveZ * Time.deltaTime), transform.position.z);
            }
            else if (distanceBetweenTarget < 30)
            {
                transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, new Vector3(StartPositon.transform.position.x, longDistance, StartPositon.transform.position.z), speedMoveZ * Time.deltaTime), transform.position.z);
            }
        }
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
        isActive = false;
        anim.SetBool("Dead", true);
    }

    public void Damage(float life)
    {
        anim.SetTrigger("Damage");

        if (life < 25)
        {
            LevelUp(3);
        }
        else if (life < 50)
        {
            LevelUp(2);
        }
        else
        {
            LevelUp(1);
        }
    }

    public void LevelUp(int lifes)
    {
        switch (lifes)
        {
            case 1:
                minDistanceTime = 0.5f;
                midleDistanceTime = 0.25f;
                longDistanceTime = 0;
                rotationSpeed = 200;
                break;

            case 2:
                minDistanceTime = 0.75f;
                midleDistanceTime = 0.5f;
                longDistanceTime = 0.25f;
                rotationSpeed = 300;
                break;

            case 3:
                minDistanceTime = 1;
                midleDistanceTime = 0.75f;
                longDistanceTime = 0.5f;
                rotationSpeed = 400;
                break;
        }
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
