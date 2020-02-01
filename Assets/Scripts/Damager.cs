using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public float backoff = 2f;
    public int damage = 30;

    private float lastHitTimestamp;

    public void Hit(Damageable target)
    {
        if (Time.time - lastHitTimestamp > backoff)
        {
            lastHitTimestamp = Time.time;
            target.TakeDamage(damage);
        }
    }
}
