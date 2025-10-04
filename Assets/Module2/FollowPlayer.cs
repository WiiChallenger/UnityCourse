using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Mike;
    public float distance = 5f;
    public float height = 3f;
    public LayerMask collisionMask;
    public float smoothSpeed = 10f;
    private Vector3 wantPos;
    public float sensitivity = 3.0f;  // Mouse sensitivity

    private float yaw = 0f;   // Horizontal rotation
    private float pitch = 20f; // Vertical rotation (default tilt)
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThirdPersonCamera();
    }

   private void FacingCamera() 
    {
        //transform.position = Mike.transform.position + new Vector3(0, 30, 0);
        //this changes the new position of the camera to MIKE!

        if (Mike != null) 
        {
        //places camera behind player???
        Vector3 objectPos = Mike.transform.position + Vector3.up * height;
        wantPos = objectPos - Mike.transform.position * distance;
            //if (Physics.Linecast(objectPos, wantPos, out RaycastHit hit, collisionMask)) 
            //{
            //    //pushes camera closer
            //    wantPos = hit.point;
            //}

            transform.LookAt(objectPos);
        }


    }

      private void ThirdPersonCamera()
    {
        if (Mike == null) return;

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        distance -= Input.GetAxis("Mouse ScrollWheel") * 2f;
        distance = Mathf.Clamp(distance, 2f, 10f);

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -20f, 60f); // limit vertical angle

        // Calculate rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Desired camera position
        Vector3 desiredPos = Mike.transform.position + rotation * new Vector3(0, height, -distance);

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

        // Always look at the target
        transform.LookAt(Mike.transform.position + Vector3.up * height * 0.5f);
    }

}

