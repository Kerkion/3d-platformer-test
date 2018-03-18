using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public bool usedOffsetValues;

	// Use this for initialization
	void Start () {
        if (!usedOffsetValues)
        {
            transform.position = target.position - offset;
        }

        offset = target.position - transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        

        transform.LookAt(target);
    }
  
}
