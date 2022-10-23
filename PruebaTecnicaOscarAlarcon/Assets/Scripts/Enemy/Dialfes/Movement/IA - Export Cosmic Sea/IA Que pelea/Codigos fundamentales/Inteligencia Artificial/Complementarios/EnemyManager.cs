using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyManager : MonoBehaviour
    {
        EnemyLocomotionManager enemyLocomotionManager;
        EnemyAnimatorManager enemyAnimatorManager;
        public bool isPreformingAction;

        public EnemyAttackAction[] enemyAttacks;
        public EnemyAttackAction currentAttack;

        [Header("A.I Settings")]
        public float detecionRadius = 20;

        //The higher, and lower, respectively these angles are, the greater detection FIELD OF VIEW (Basically like eye sight
        //
        public float maximunDetecionAngle = 50;
        public float minimunDetecionAngle = 50;

        void Awake()
        {
            enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        }

        void Update()
        {
           
        }
        private void FixedUpdate()
        {
            HandleCurrentAction();
        }
        public void HandleCurrentAction()
        {
            if (enemyLocomotionManager.currentTarget == null)
            {
                enemyLocomotionManager.HandleDetecion();
            }
            else if(enemyLocomotionManager.distanceFromTarget > enemyLocomotionManager.stoppingDistance)
            {
                enemyLocomotionManager.HandleMoveToTarget();
            }
            else if(enemyLocomotionManager.distanceFromTarget <= enemyLocomotionManager.stoppingDistance)
            {
                //Handle our attacks
            }
        }
        #region Attacks
        private void AttackTarget()
        {
            if (currentAttack == null)
            {
                GetNewAttack();
            }
        }
        private void GetNewAttack()
        {
            Vector3 targetDirection = enemyLocomotionManager.currentTarget.transform.position - transform.position;
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
            enemyLocomotionManager.distanceFromTarget = Vector3.Distance(enemyLocomotionManager.currentTarget.transform.position, transform.position);


            int maxScore = 0;
            for (int i = 0; i < enemyAttacks.Length; i++)
            {
                EnemyAttackAction enemyAttackAction = enemyAttacks[i];
                if (enemyLocomotionManager.distanceFromTarget <= enemyAttackAction.MaximunDistanceNeedToAttack
                    && enemyLocomotionManager.distanceFromTarget >= enemyAttackAction.minimunDistanceNeedToAttack)
                {
                    if (viewableAngle <= enemyAttackAction.maximunAttackAngle
                        && viewableAngle >= enemyAttackAction.minimunDistanceNeedToAttack)
                    {
                        maxScore += enemyAttackAction.attackScore;
                    }
                }
            }
            int randomValue = Random.Range(0, maxScore);
            int temporaryScore = 0;
            for (int i = 0; i < enemyAttacks.Length; i++)
            {
                EnemyAttackAction enemyAttackAction = enemyAttacks[i];
                if (enemyLocomotionManager.distanceFromTarget <= enemyAttackAction.MaximunDistanceNeedToAttack
                    && enemyLocomotionManager.distanceFromTarget >= enemyAttackAction.minimunDistanceNeedToAttack)
                {
                    if (viewableAngle <= enemyAttackAction.maximunAttackAngle
                       && viewableAngle >= enemyAttackAction.minimunAttackAngle)
                    {
                        if (currentAttack != null)
                        
                            return;
                        temporaryScore += enemyAttackAction.attackScore;
                        if (temporaryScore > randomValue)
                        {
                            currentAttack = enemyAttackAction;
                        }
                        
                        maxScore += enemyAttackAction.attackScore;
                    }
                }
            }
        }

        #endregion
    }
}
