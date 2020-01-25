using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
    }
}
