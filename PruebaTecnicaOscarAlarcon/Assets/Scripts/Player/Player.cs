using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public int lifes;
    public int Ammo;
    public float currentTimeSpawn;
    public float timeToSpawn;
    public bool isActive;
    public CannonController shootController;
    public GameObject letrero;
    public GameObject targetPoint;
    public bool IsActive { get => isActive; set => isActive = value; }

    void Start()
    {
        shootController = GetComponentInChildren<CannonController>();
        lifes = 2;
        currentTimeSpawn = timeToSpawn;
    }

    public void Die()
    {
        SimpleSampleCharacterControl.Instance.SendAnimationReaction(2);
        isActive = false;
    }

    void Update()
    {
        if (IsActive)
        {
            currentTimeSpawn++;
        }
    }
    
    public void Attack()
    {
        shootController.Shooting();
        Debug.Log("attack");
    }

    public void Damage()
    {
        lifes--;

        if (lifes == 0)
        {
            Instance.Die();
            ManagerGame.Instance.FinishGame();
        }
        else
        {
            SimpleSampleCharacterControl.Instance.SendAnimationReaction(0);
            SoundManager.Instance.PlayNewSound("PlayerDamage");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Damage();
            Destroy(other.gameObject);
        }


        if (other.CompareTag("EnemyBody"))
        {
            Damage();
        }

        if (other.CompareTag("HealtItem"))
        {
            if (lifes <= 3 )
            {
                lifes++;
            }
            //reproducir sonido

            SoundManager.Instance.PlayNewSound("GetItem");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("TimeItem"))
        {
            ManagerGame.Instance.timer.RestaurarTiempo(10f);
            StartCoroutine(Letrero());
            SoundManager.Instance.PlayNewSound("GetItem");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("AmmoItem"))
        {
            Ammo++;
            Ammo++;
            Ammo++;
            Destroy(other.gameObject);
            SoundManager.Instance.PlayNewSound("GetItem"); 
        }
    }

    IEnumerator Letrero()
    {
        letrero.SetActive(true);
        yield return new WaitForSeconds(5f);
        letrero.SetActive(false);
    }
}
