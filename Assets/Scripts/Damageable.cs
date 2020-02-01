using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 1)
        {
            Die();
        } else
        {
            Debug.Log(gameObject.name + ": health=" + health);
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + ": died.");
        Destroy(gameObject);
    }
}
