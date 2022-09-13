using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetected : MonoBehaviour
{
    [SerializeField] int damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            return;

        if (other.gameObject.tag == "Player")
        {
            EnemyBoss.Instance.healt.TakeDamage(damage);

        }

        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            SoundManager.Instance.PlayNewSound("EnemyDamage");
            EnemyBoss.Instance.healt.TakeDamage(damage);
        }
    }
}
