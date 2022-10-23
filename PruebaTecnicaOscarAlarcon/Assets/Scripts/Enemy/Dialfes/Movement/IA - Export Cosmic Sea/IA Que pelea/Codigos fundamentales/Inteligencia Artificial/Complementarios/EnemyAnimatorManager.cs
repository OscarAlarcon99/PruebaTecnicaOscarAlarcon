using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyAnimatorManager : AnimatorManager
    {
        EnemyLocomotionManager enemyLocomotionManger;
        private void Awake()
        {
            anim = GetComponent<Animator>();
            enemyLocomotionManger = GetComponentInParent<EnemyLocomotionManager>();
        }
        private void OnAnimatorMove()
        {
            float delta = Time.deltaTime;
            enemyLocomotionManger.enemyRigidbody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            enemyLocomotionManger.enemyRigidbody.velocity = velocity;
        }
    }
}
