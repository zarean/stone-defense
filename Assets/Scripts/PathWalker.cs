using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWalker : MonoBehaviour
{
    public float speed;
    public Transform path;
    private Transform[] pathNodes;
    float progress = 0.0f;
    float pathLength;

    // Start is called before the first frame update
    void Start()
    {
	    pathNodes = path.GetComponentsInChildren<Transform>();
        pathLength = iTween.PathLength(pathNodes);
    }

    void FixedUpdate()
    {
        progress += Time.fixedDeltaTime * speed / pathLength;
        iTween.PutOnPath(gameObject, pathNodes, progress);
        if (progress >= 1)
        {
            Debug.Log("Enemy Reached End.");
            Destroy(gameObject);
        }
    }
}
