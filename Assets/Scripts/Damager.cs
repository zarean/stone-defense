using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damage;

    public void Hit(Damageable target)
    {
        target.TakeDamage(damage);
    }
}
