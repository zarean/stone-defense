using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoner : MonoBehaviour
{
    public Damager damager;

    private Damageable target;

    void Start()
    {
        damager = gameObject.GetComponent<Damager>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            damager.Hit(target);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Damageable enemy = other.GetComponent<Damageable>();
        if (enemy != null)
        {
            target = enemy;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Damageable enemy = other.GetComponent<Damageable>();
        if (enemy != null)
        {
            target = null;
        }
    }
}
