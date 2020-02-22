using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StoneDefense
{
    public class Projectile : MonoBehaviour
    {
        public Damageable target;
        public float speed;

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
            if(target == null)
            {
                Destroy(gameObject);
            }
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.gameObject.transform.position, speed * Time.fixedDeltaTime);
            gameObject.transform.Rotate(0, 0, 360f * Time.fixedDeltaTime, Space.Self);
        }
    }
}