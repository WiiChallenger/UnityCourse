using UnityEngine;

public class BasicLevelControl : MonoBehaviour
{
    private bool cursorToggled = true;
    void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void LockCursor()
    {
        Cursor.visible = false;

        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }
    void UnlockCursor()
    {
   
            Cursor.visible = true;

            // Lock the cursor to the center of the screen
            Cursor.lockState = CursorLockMode.None;
    }

    private void CursorToggle()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
        Cursor.visible = !Cursor.visible;
            if (cursorToggled)
            {
                LockCursor();
            }
            else
            {
               UnlockCursor();
            }
             
        
        }
        
    }
}

