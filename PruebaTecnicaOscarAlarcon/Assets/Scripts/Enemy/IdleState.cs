using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Enter(EnemyBoss enemyBoss)
    {
        base.Enter(enemyBoss);
        mainParent.anim.SetBool("Shoot", false);
    }

    public override void Update()
    {
        if (mainParent.DefaultRotation != mainParent.Rotator.rotation)
        {
            //mainParent.Rotator.rotation = Quaternion.RotateTowards(
            //    mainParent.Rotator.rotation, mainParent.DefaultRotation,
            //    Time.deltaTime * mainParent.RotationSpeed);
        }

        if (mainParent.Target != null)
        {
            if (mainParent.CanSeeTarget(((mainParent.Target.position +
                 mainParent.AimOffset) - mainParent.GunBarrel.position),
                    mainParent.GunBarrel.position, "Player"))
            {
                mainParent.ChangeState(new FindTargetState());
            }
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainParent.Target = other.transform;
            mainParent.ChangeState(new FindTargetState());
        }
    }
}
