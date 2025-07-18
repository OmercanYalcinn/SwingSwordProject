using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Camera mainCamera;
    public bool canLook = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hiding system cursor first
        Cursor.visible = false;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (canLook)
            PlayerLookAtMouse();
    }

    void PlayerLookAtMouse()
    {
        // Gets the mouse position in world space
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Ensure it's in 2D plane

        // Calculates the angle from the player to the mouse with the tangent Atan2 function
        Vector3 direction = mousePos - transform.position;
        // To see what direction it's aiming
        Debug.DrawLine(transform.position, mousePos, Color.green);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotates the player so its "right" side faces the mouse 
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f); // my 'up' is forward
    }
}
