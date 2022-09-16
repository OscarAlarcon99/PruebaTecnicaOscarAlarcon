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
            Debug.Log("fueaqui");
            EnemyBoss.Instance.healt.TakeDamage(damage);
            SoundManager.Instance.PlayNewSound("EnemyDamage");
        }


        if (other.gameObject.tag == "PlayerBullet")
        {
            other.gameObject.GetComponent<Cañon>().Explotar();
            SoundManager.Instance.PlayNewSound("EnemyDamage");
        }
    }
}
