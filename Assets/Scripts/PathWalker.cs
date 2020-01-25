using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWalker : MonoBehaviour
{
    public float speed = 5;
    public Transform path;
    public Transform[] pathNodes;
    float progress = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
	    pathNodes = path.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        progress += speed * 0.01f * Time.deltaTime;
        iTween.PutOnPath(gameObject, pathNodes, progress);
    }
}
