using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetected : MonoBehaviour
{
    [SerializeField] int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Explotion")
        {
            EnemyBoss.Instance.healt.TakeDamage(damage);
            SoundManager.Instance.PlayNewSound("EnemyDamage");
        }
    }
}
