using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace StoneDefense
{
    public class GameController : MonoBehaviour
    {
        public UnityEvent OnEnemyGotThrough;

        public int extinctionThreshold;
        private int deathsCount = 5;

        public GameObject[] enemyPrefabs;
        public Transform path;

        private float time = 0;
        private int i = 0;

        public int DeathsCount { get { return deathsCount; } }

        void Update()
        {
            if( i < enemyPrefabs.Length ) {
                time += Time.deltaTime;
                if (time > 2) {
                    time = 0;
                    GameObject enemy = Instantiate(enemyPrefabs[i], transform.position, Quaternion.identity);
                    enemy.GetComponent<PathWalker>().path = path;
                    i++;
                }
            }
        }

        public void EnemyGotThrough()
        {
            ++deathsCount;
            OnEnemyGotThrough.Invoke();
        }
    }
}