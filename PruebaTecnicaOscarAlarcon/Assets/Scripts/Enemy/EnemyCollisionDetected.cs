using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetected : MonoBehaviour
{
    [SerializeField] int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SoundManager.Instance.PlayNewSound("EnemyDamage");
            EnemyBoss.Instance.healt.TakeDamage(damage);
        }

        if (other.gameObject.tag == "PlayerBullet")
        {
            //SoundManager.Instance.PlayNewSound("EnemyDamage");
            EnemyBoss.Instance.healt.TakeDamage(damage);
            Destroy(other.gameObject);
        }
    }
}
