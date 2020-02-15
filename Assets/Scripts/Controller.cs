using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform path;

    float time = 0;
    int i = 0;

    // Update is called once per frame
    void Update()
    {
        if( i < prefabs.Length ) {
            time += Time.deltaTime;
            if (time > 5) {
                time = 0;
                GameObject enemy = Instantiate(prefabs[i], transform.position, Quaternion.identity);
                enemy.GetComponent<PathWalker>().path = path;
                i++;
            }
        }
    }
}
