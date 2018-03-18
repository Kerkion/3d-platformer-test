using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public bool usedOffsetValues;
    public float rotateSpeed;
    public Transform pivot;

	// Use this for initialization
	void Start () {
        if (!usedOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void LateUpdate()
    {
        //Get xPos of mouse & rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //Get YPos of mouse & rotate pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        //Move camera based on curr rotation of target and original offset
        float desYAngle = target.eulerAngles.y;
        float desXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desXAngle, desYAngle, 0);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }

        transform.LookAt(target);
    }
  
}
