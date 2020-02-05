using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoner : MonoBehaviour
{
    public float shotBackoff = 2f;
    public GameObject projectilePrefab;

    private float lastShotTimestamp;
    private Damageable target;

    void FixedUpdate()
    {
        if (target != null && Time.time - lastShotTimestamp > shotBackoff)
        {    
            lastShotTimestamp = Time.time;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().target = target;
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
