using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State
{
    public override void Enter(EnemyBoss enemyBoss)
    {
        base.Enter(enemyBoss);
        mainParent.anim.SetBool("Shoot",true);
    }

    public override void Update()
    {
        if (mainParent.Target != null)
        {
            mainParent.Rotator.LookAt(mainParent.Target.position + mainParent.AimOffset);
        }

        if (!mainParent.CanSeeTarget(mainParent.GunBarrel.forward, mainParent.Rotator.position, "Player"))
        {
            mainParent.ChangeState(new IdleState());
        }

    }
}
