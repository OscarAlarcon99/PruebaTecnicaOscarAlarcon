using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;

    [SerializeField]
    Transform shootPosition;



    public void Shooting()
    {
        Quaternion headingDirection = Quaternion.FromToRotation(projectile.transform.forward,
        EnemyBoss.Instance.GunBarrel.forward);
        GameObject instance = Instantiate(projectile, EnemyBoss.Instance.GunBarrel.position, headingDirection);
        instance.GetComponent<Projectile>().Direction = EnemyBoss.Instance.GunBarrel.forward;
        SoundManager.Instance.PlayNewSound("AttackEnemy");
        Destroy(instance, 15f);
    }
}
