using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetState : State
{
    public override void Update()
    {
        mainParent.GhostRotator.LookAt(mainParent.Target.position + mainParent.AimOffset);

        mainParent.Rotator.rotation = Quaternion.RotateTowards(
            mainParent.Rotator.rotation, mainParent.GhostRotator.rotation,
            Time.deltaTime * mainParent.RotationSpeed);

        mainParent.CalculateDistanceBetweenTarget();

        if (mainParent.GhostRotator.rotation.y == mainParent.Rotator.rotation.y &&
            mainParent.CanSeeTarget(mainParent.GunBarrel.forward, mainParent.Rotator.position, "Player"))
        {
            mainParent.ChangeState(new ShootState());
        }
    }
}
