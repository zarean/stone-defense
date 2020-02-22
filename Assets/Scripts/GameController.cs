using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace StoneDefense
{
    public class GameController : MonoBehaviour
    {
        public UnityEvent OnEnemyGotThrough;

        public int extinctionThreshold;
        private int deathsCount = 5;

        public Transform path;
        public Wave[] waves;
    

        private int currentWave = 0;
        private int currentEntrance = 0;

        public int DeathsCount { get { return deathsCount; } }

        private float time = 0;

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
            time += Time.deltaTime;
            if( currentWave < waves.Length ) {
                if (time > waves[currentWave].time + waves[currentWave].entrances[currentEntrance].time) {
                    GameObject enemy = Instantiate(waves[currentWave].entrances[currentEntrance].prefab, transform.position, Quaternion.identity);
                    enemy.GetComponent<PathWalker>().path = path;
                    currentEntrance++;
                    if( waves[currentWave].entrances.Length <= currentEntrance ) 
                    {
                        currentEntrance = 0;
                        currentWave++;
                    }
                }
            }
        }

        public void EnemyGotThrough()
        {
            ++deathsCount;
            OnEnemyGotThrough.Invoke();
        }
    }

    [System.Serializable]
    public class Entrance
    {
        public float time;
        public GameObject prefab;
    }

    [System.Serializable]
    public class Wave
    {
        public float time;
        public Entrance[] entrances;
    }
}