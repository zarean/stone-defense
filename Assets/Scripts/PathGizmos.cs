using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGizmos : MonoBehaviour
{
    void OnStart()
    {
    }

    void OnDrawGizmos()
    {
        Transform[] path = gameObject.transform.GetComponentsInChildren<Transform>();
        iTween.DrawPath(path);
        Gizmos.color = Color.blue;
        foreach(Transform t in path) 
        {
            Gizmos.DrawSphere(t.position, 0.1f);
        }
    }
    
}
