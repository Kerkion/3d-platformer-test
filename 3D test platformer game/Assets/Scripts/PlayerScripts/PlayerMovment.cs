using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    public float speed;
    public float jump;
    public float gravityScale;

    private CharacterController charCon;
    private Vector3 moveDirection;

    
    

	// Use this for initialization
	void Start () {
        charCon = GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, Input.GetAxis("Vertical") * speed);

        if (charCon.isGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                moveDirection.y = jump;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.fixedDeltaTime);

        charCon.Move(moveDirection * Time.fixedDeltaTime);

    }

}
