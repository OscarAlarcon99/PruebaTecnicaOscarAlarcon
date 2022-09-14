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

    
    public Sound[] fx_Sound;
    public bool IsActive { get => isActive; set => isActive = value; }

    void Start()
    {
        lifes = 3;
        currentTimeSpawn = timeToSpawn;
    }

    public void Die()
    {
        SimpleSampleCharacterControl.Instance.m_animator.SetBool("Dead", true);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (IsActive)
        {
            currentTimeSpawn++;
        }
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
            //SoundManager.Instance.PlayNewSound(Player.Instance.fx_Sound[0].name);
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
            Destroy(other.gameObject);
        }

        if (other.CompareTag("TimeItem"))
        {
            ManagerGame.Instance.timer.RestaurarTiempo(10f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("AmmoItem"))
        {
            Ammo++;
            Ammo++;
            Ammo++;
            Destroy(other.gameObject);
        }
    }
}
