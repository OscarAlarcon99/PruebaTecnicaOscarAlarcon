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

        if (mainParent.GhostRotator.rotation.y == mainParent.Rotator.rotation.y)
        {
            mainParent.ChangeState(new ShootState());
        }
    }
}
