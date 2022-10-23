using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    [CreateAssetMenu(menuName = "A.I/Enemy Actions / Attack Action")]
    public class EnemyAttackAction : MonoBehaviour
    {
        public int attackScore = 3;
        public float recoveryTime = 2;

        public float maximunAttackAngle = 35;
        public float minimunAttackAngle = -35;

        public float minimunDistanceNeedToAttack = 0;
        public float MaximunDistanceNeedToAttack = 3;

    }
}