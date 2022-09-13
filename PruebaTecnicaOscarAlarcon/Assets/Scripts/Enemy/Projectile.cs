using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float speed;

    void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime, Space.World);
    }
}
