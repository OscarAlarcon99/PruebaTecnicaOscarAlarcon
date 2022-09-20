using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public float timeDestroy;
    public GameObject particula;
    public Coroutine coroutine;

    void Start()
    {
        coroutine = StartCoroutine(ManualExplotion());
    }

    IEnumerator ManualExplotion()
    {
        yield return new WaitForSeconds(timeDestroy);
        Explotar();
    }

    public void Explotar()
    {
        Destroy(Instantiate(particula, transform.position, Quaternion.identity), 2f);
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBody") || other.CompareTag("Player") || other.CompareTag("EnemyBullet"))
        {
            if (other.CompareTag("EnemyBullet"))
            {
                Destroy(other);
            }

            StopCoroutine(coroutine);
            Explotar();
        }
    }
}
