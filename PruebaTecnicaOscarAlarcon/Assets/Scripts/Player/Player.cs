using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public Ray ray;
    public int lifes;
    [SerializeField] int Ammo;
    [SerializeField] float currentTimeSpawn;
    [SerializeField] float timeToSpawn;
    [SerializeField] bool isActive;
    [SerializeField] GameObject poder_invierno;
    [SerializeField] GameObject spawnPoint;
    
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
            ray = new Ray(transform.position, EnemyBoss.Instance.transform.position);
            Debug.DrawRay(transform.position, ray.direction, Color.green);
            currentTimeSpawn++;
        }
    }

    public void Attack()
    {
        if (IsActive && currentTimeSpawn > timeToSpawn)
        {
            
            //Destroy(Instantiate(poder_invierno, spawnPoint.transform.forward, Quaternion.identity), 20f);
            //ProjectileMoveScript poder = pooling.GetPooledObjects().GetComponent<ProjectileMoveScript>();
            //poder.Start();
            //poder.gameObject.SetActive(true);
            
            Quaternion headingDirection = Quaternion.FromToRotation(poder_invierno.transform.forward,
                spawnPoint.transform.forward);

            Instantiate(poder_invierno, spawnPoint.transform.position, headingDirection).GetComponent<Projectile>()
                .Direction = spawnPoint.transform.forward;
            
            currentTimeSpawn = 0;
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
            Destroy(other.gameObject);
        }

        if (other.CompareTag("AmmoItem"))
        {
            Ammo++;
            Destroy(other.gameObject);
        }
    }
}
