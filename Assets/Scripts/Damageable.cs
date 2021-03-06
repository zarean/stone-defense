﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StoneDefense
{
    public class Damageable : MonoBehaviour
    {
        public int maxHealth;
        public Transform healthBar;

        private int currentHealth;

        public void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth < 1)
            {
                Die();
            }
            healthBar.localScale = new Vector3(currentHealth / (float)maxHealth, 1, 1);
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}