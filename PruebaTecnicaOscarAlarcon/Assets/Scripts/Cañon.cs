using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public float timeDestroy;
    public BoxCollider collider;
    public GameObject particula;
    public GameObject body;
    public Rigidbody rigidbody;

    void Start()
    {
        Invoke("Explotar", timeDestroy);
    }

    public void Explotar()
    {
        body.SetActive(false);
        body.GetComponentInParent<SphereCollider>().enabled = false;
        collider.enabled = true;
        particula.gameObject.SetActive(true);
        Destroy(rigidbody);
        Destroy(this.gameObject, 2f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBody"))
        {
            EnemyBoss.Instance.healt.TakeDamage(20);
        }

        if (other.CompareTag("Player"))
        {
            Player.Instance.Damage();
        }
    }
}
