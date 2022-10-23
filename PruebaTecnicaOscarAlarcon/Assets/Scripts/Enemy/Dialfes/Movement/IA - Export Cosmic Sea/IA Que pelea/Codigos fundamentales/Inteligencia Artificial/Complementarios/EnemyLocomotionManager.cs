using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SG
{

    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        EnemyAnimatorManager enemyAnimatorManager;

        NavMeshAgent navMeshAgent;
        public Rigidbody enemyRigidbody;

        public CharacterStats currentTarget;
        public LayerMask detecionLayer;

        public float distanceFromTarget;
        public float stoppingDistance = 1f;

        public float rotationSpeed = 15;

        public void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            enemyRigidbody = GetComponent<Rigidbody>();
        }
        public void Start()
        {
            navMeshAgent.enabled = false;
            enemyRigidbody.isKinematic = false;
        }
        public void HandleDetecion()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detecionRadius, detecionLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();
                if (characterStats != null)
                {
                    //Check for team id
                    Vector3 targetDirection = characterStats.transform.position - transform.position;
                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                    if (viewableAngle > enemyManager.minimunDetecionAngle && viewableAngle < enemyManager.maximunDetecionAngle)
                    {
                        currentTarget = characterStats; 
                    }
                }
            }
        }
        public void HandleMoveToTarget()
        {
            Vector3 targetDirection = currentTarget.transform.position - transform.position;
            distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position);
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
            if (enemyManager.isPreformingAction)
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                navMeshAgent.enabled = false;
            }
            else
            {
                if (distanceFromTarget > stoppingDistance)
                {
                  //  enemyAnimatorManager.anim.SetFloat("Vertical", 1f, 0, 1f, Time.deltaTime);
                }
                else if(distanceFromTarget <= stoppingDistance)
                {
                   // enemyAnimatorManager.anim.SetFloat("Vertical", 0f, 0, 1f, Time.deltaTime);
                }
            }
            HandleRotateTowardsTarget();
            navMeshAgent.transform.localPosition = Vector3.zero;
            navMeshAgent.transform.localRotation = Quaternion.identity;

        }
        private void HandleRotateTowardsTarget()
        {
            if (enemyManager.isPreformingAction)
            {
                Vector3 direction = currentTarget.transform.position - transform.position;
                direction.y = 0;
                direction.Normalize();
                if (direction == Vector3.zero)
                {
                    direction = transform.forward;
                }
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
            }
            else
            {
                Vector3 rolativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity);
                Vector3 targetVelocity = enemyRigidbody.velocity;

                navMeshAgent.enabled = true;
                navMeshAgent.SetDestination(currentTarget.transform.position);
                enemyRigidbody.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime);

            }

        }
    }
}
