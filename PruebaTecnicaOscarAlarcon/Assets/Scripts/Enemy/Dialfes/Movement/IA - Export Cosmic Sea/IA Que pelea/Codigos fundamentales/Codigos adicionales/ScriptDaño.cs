using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDaño : MonoBehaviour
{
    public float timeBeweenAttacks = 0.5f; //TiempoEntreAtaques
    public int attackDamage = 10; //Daño

    Animator anim;
    GameObject Enemy;
    EnemyHealth enemyHealth;
    bool EnemyInRange; //EnemigoEnRango
    float timer;

    private void Awake()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = Enemy.GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBeweenAttacks && EnemyInRange)
        {
            Attack();
        }
        if (enemyHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead"); //Llamar Al EstadoMuerte
        }
    }
    void Attack()
    {
        timer = 0f;
        if (enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDamage, Enemy.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Enemy)
        {
            EnemyInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Enemy)
        {
            EnemyInRange = false;
        }

    }
}
