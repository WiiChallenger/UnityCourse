using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //primitive variables.
    //float, int, double, char, bool, string, --
   //camelCasing, WhatEverCasing, _localCasing, -LocalCasing
    public float moveSpeed = 10f;
    private float runSpeed = 20f;
    private Vector3 startPosition;

    //Simmilar to godot when accessing an object
    // :)
    private Rigidbody rb;

  void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        HandleRawMovement();
        PlayerReset();
    }

# region void AdvancedMovementHandler
    //{
    ////values from the keyboard
    //horizontalMovement = Input.GetAxis("Horizontal");
    //    verticalMovement = Input.GetAxis("Vertical");

    //    // Vector == position // make new vector for the input position
    //    Vector3 move = new Vector3(horizontalMovement, 0, verticalMovement) * moveSpeed * Time.fixedDeltaTime;
    //rb.MovePosition(rb.position + move);
    //}
#endregion
private void HandleRawMovement()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = transform.position + Vector3.forward * (runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Vector3.forward * (moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = transform.position + Vector3.back * (runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            transform.position = transform.position + Vector3.back * (moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = transform.position + Vector3.left * (runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left * (moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = transform.position + Vector3.right * (runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            transform.position = transform.position + Vector3.right * (moveSpeed * Time.deltaTime);
        }
    }

     void PlayerReset() 
    {
        if (transform.position.y < -5) 
        {
            transform.position = startPosition;

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;   // stops all linear movement
                rb.angularVelocity = Vector3.zero;  // stops all spinning/rotation
            }
        }

    }


    #region OldMovementCode
    //if a condition is met,
    //Do this things.
    //else, do this other thing. 

    //Vector3(x, y, z)

    //if (Input.GetKey(KeyCode.D))
    //{
    //  Vector3 movementRight = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    //  transform.Translate(movementRight);
    //}

    // if (Input.GetKey(KeyCode.A)) 
    //{ 
    //   Vector3 movementLeft = new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
    //   transform.Translate(movementLeft);
    //}

    //if (Input.GetKey(KeyCode.W))
    //{
    //  Vector3 movementLeft = new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
    //  transform.Translate(movementLeft);
    //}

    //if (Input.GetKey(KeyCode.S))
    //{
    //  Vector3 movementLeft = new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
    //  transform.Translate(movementLeft);
    //}
    #endregion

}
