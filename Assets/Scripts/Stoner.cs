using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StoneDefense
{
    public class Stoner : MonoBehaviour
    {
        public float shotBackoff;
        public GameObject projectilePrefab;
        public Transform throwingPoint;
        public float projectileSecondsInAir;

        private float lastShotTimestamp;
        private List<Damageable> targets = new List<Damageable>{};
        void Start()
        {
            lastShotTimestamp = -1 * shotBackoff;
        }

        void FixedUpdate()
        {
            if (targets.Count != 0 && Time.time - lastShotTimestamp > shotBackoff)
            {    
                lastShotTimestamp = Time.time;
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectile.GetComponent<Projectile>().secondsInAir = projectileSecondsInAir;
                projectile.GetComponent<Projectile>().target = targets[0];
                projectile.GetComponent<Projectile>().source = throwingPoint.position;
                projectile.GetComponent<Projectile>().destination = targets[0].GetComponent<PathWalker>().GetFuturePosition(projectileSecondsInAir);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Damageable enemy = other.GetComponent<Damageable>();
            if (enemy != null)
            {
                targets.Add(enemy);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            Damageable enemy = other.GetComponent<Damageable>();
            if (enemy != null)
            {
                targets.Remove(enemy);
            }
        }
    }
    }