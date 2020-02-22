using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StoneDefense
{
    public class Projectile : MonoBehaviour
    {
        public Damageable target;
        public float secondsInAir;
        public Vector3 source;
        public Vector3 destination;
        private Vector3[] path;
        private float progress;

        private Damager damager;

        void Start()
        {
            path = new Vector3[] {source, (source + destination) / 2 + Vector3.up * 1.0f, destination};
            damager = GetComponent<Damager>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Damageable damagable = other.GetComponent<Damageable>();
            if (progress > 0.5 && damagable == target) 
            {
                damager.Hit(target);
                Destroy(gameObject);
            }
        }

        void FixedUpdate()
        {
            progress += Time.fixedDeltaTime / secondsInAir;
            iTween.PutOnPath(gameObject, path, progress);
            if (progress >= 1)
            {
                Destroy(gameObject);
            }
            gameObject.transform.Rotate(0, 0, 360f * Time.fixedDeltaTime, Space.Self);
        }
    }
}