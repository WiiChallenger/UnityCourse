using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //primitive variables.
    //float, int, double, char, bool, string, --
   //camelCasing, WhatEverCasing, _localCasing, -LocalCasing
    public Transform cameraTransform;
    private UnityEngine.Vector3 startPosition;
    public float moveSpeed = 10f;
    private float moveSpeedMultiplier = 3f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;


    //Simmilar to godot when accessing an object
    // :)
    private Rigidbody rb;

  void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        AdvancedMovementHandler();
        PlayerReset();
    }

void AdvancedMovementHandler()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        UnityEngine.Vector3 wantDirection = new UnityEngine.Vector3(h, 0f, v).normalized;

        if (wantDirection.magnitude > turnSmoothTime)
        {
            //bla bla complex math for gaining target angle
            float targetAngle = Mathf.Atan2(wantDirection.x, wantDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            //smooth rotation tward angel
            float angle = Mathf.SmoothDampAngle(cameraTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = UnityEngine.Quaternion.Euler(0f, angle, 0f);

            //at this point forcing all vectors to UnityEngine Abiguity... WAY TO BIG OF TERMS Something like Unreliable unstable??
            // Movement direction
            UnityEngine.Vector3 moveDirection = UnityEngine.Quaternion.Euler(0f, targetAngle, 0f) * UnityEngine.Vector3.forward;


            // For the best result set speed as a local variable then multiply for run!
            // if not otherwise it's a POS! It will not function!
            float speed = moveSpeed;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speed = moveSpeed * moveSpeedMultiplier;
            }
            transform.position += moveDirection.normalized * speed * Time.deltaTime;
        }
    }

#region void HandleRawMovement()
    //{
    //    if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
    //    {
    //        transform.position = transform.position + UnityEngine.Vector3.forward * (runSpeed * Time.deltaTime);
    //    }
    //    else if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.position = transform.position + UnityEngine.Vector3.forward * (moveSpeed * Time.deltaTime);
    //    }
    //    if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
    //    {
    //        transform.position = transform.position + UnityEngine.Vector3.back * (runSpeed * Time.deltaTime);
    //    }
    //    else if (Input.GetKey(KeyCode.S)) 
    //    {
    //        transform.position = transform.position + UnityEngine.Vector3.back * (moveSpeed * Time.deltaTime);
    //    }
    //    if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
    //    {
    //        transform.position = transform.position + UnityEngine.Vector3.left * (runSpeed * Time.deltaTime);
    //    }
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.position = transform.position + UnityEngine.Vector3.left * (moveSpeed * Time.deltaTime);
    //    }
    //    if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
    //    {
    //        transform.position = transform.position + UnityEngine.Vector3.right * (runSpeed * Time.deltaTime);
    //    }
    //    else if (Input.GetKey(KeyCode.D)) 
    //    {
    //        transform.position = transform.position + UnityEngine.Vector3.right * (moveSpeed * Time.deltaTime);
    //    }
    //}
#endregion

     void PlayerReset() 
    {
        if (transform.position.y < -5) 
        {
            transform.position = startPosition;

            if (rb != null)
            {
                rb.linearVelocity = UnityEngine.Vector3.zero;   // stops all linear movement
                rb.angularVelocity = UnityEngine.Vector3.zero;  // stops all spinning/rotation
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
