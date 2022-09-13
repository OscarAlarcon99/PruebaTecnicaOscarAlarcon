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
    public bool IsActivate { get { return isActive; } }

    void Start()
    {
        lifes = 3;
        currentTimeSpawn = timeToSpawn;
    }

    public void StateController()
    {
        isActive = !isActive;
    }

    public void Die()
    {
        SimpleSampleCharacterControl.Instance.m_animator.SetBool("Dead", true);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (isActive)
        {
            //ray = new Ray(transform.position, Enemy.Instance.transform.position);
            //Debug.DrawRay(transform.position, ray.direction, Color.green);
            //Debug.Log("aqui " + movimiento.crossFire.transform.position);
            currentTimeSpawn++;
        }
    }

    public void Attack()
    {
        if (isActive && currentTimeSpawn > timeToSpawn)
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
        if (lifes != 0)
        {
            //SoundManager.Instance.PlayNewSound(Player.Instance.fx_Sound[0].name);
            lifes--;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Damage();
        }

        if (other.CompareTag("Caja"))
        {
            Ammo++;
        }

        //other.gameObject.SetActive(false);

    }
}
