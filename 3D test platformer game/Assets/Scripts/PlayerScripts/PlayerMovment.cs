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
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * speed;
        moveDirection.y = yStore;

        if (charCon.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetKeyDown("space"))
            {
                moveDirection.y = jump;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.fixedDeltaTime);

        charCon.Move(moveDirection * Time.fixedDeltaTime);

    }

}
