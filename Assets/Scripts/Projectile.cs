using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Damageable target;

    private float speed = 2f;
    private Damager damager;

    void Start()
    {
        damager = GetComponent<Damager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damagable = other.GetComponent<Damageable>();
        if (damagable == target) 
        {
            damager.Hit(target);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.gameObject.transform.position, speed * Time.fixedDeltaTime);
    }
}
