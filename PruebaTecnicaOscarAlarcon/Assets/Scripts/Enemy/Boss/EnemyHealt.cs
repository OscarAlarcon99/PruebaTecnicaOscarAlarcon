using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    public float health;

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        SoundManager.Instance.PlayNewSound("DamageEnemy");

        if (health <= 0)
        {
            EnemyBoss.Instance.Die();
        }
        else
        {
            EnemyBoss.Instance.Damage(health);
        }
    }
}
