using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Mike;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraOffSet();
    }

    void CameraOffSet() 
    {
        transform.position = Mike.transform.position + new Vector3(0, 30, 0);
        //this changes the new position of the camera to MIKE!
    }
}
