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

    private float minDistance;
    private float midleDistance;
    private float longDistance;

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
           DistanceBetweenTarget = Vector3.Distance(this.transform.position, Player.Instance.transform.position);

            if (distanceBetweenTarget < 7)
            {
                ChangeFiringRate(minDistance);
            }
            else if (distanceBetweenTarget < 15)
            {
                ChangeFiringRate(midleDistance);
            }
            else
            {
                ChangeFiringRate(longDistance);
            }

        }
    }
    void ChangeFiringRate(float value)
    {
        anim.SetFloat("VelAttack", value);
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
        Debug.Log("Start New State : " + newState);

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
                minDistance = 0.5f;
                midleDistance = 0.25f;
                longDistance = 0;
                rotationSpeed = 200;
                break;

            case 2:
                minDistance = 0.75f;
                midleDistance = 0.5f;
                longDistance = 0.25f;
                rotationSpeed = 300;
                break;

            case 3:
                minDistance = 1;
                midleDistance = 0.75f;
                longDistance = 0.5f;
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
