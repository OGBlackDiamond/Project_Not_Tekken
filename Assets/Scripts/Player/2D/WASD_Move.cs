using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class WASD_Move : MonoBehaviour
{
    /*
     * An action reference is created using a feild, it is used to 
     * reference the specific action, more can be added as needed
    */
    [SerializeField] private float playerSpeed, rollPlayerSpeed, rollSeconds;
    [SerializeField] private InputActionReference movement, roll;
    [SerializeField] private BoxCollider2D body;

    private Vector2 movementInput;

    private Color color = new Color(0, 255, 0);


    private bool rolling;



    // runs when the object is instantiated and becomes active
    private void OnEnable()
    {
        // adds a method call to the action when the button is pressed (performed)
        roll.action.performed += Roll;
    }

    // reverse of enable lawl
    private void OnDisable()
    {
        // reverse of enable lawl
        roll.action.performed -= Roll;
    }

    private void Update()
    {
        // refreshes the movement input when not rolling
        movementInput = rolling? movementInput : movement.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (transform.position != body.transform.position)
        {
            Debug.Log("Balls");
        }
        // moves 100 times every second
        regularMovement(movementInput.x, movementInput.y);
        //Debug.Log(transform.position);
        checkCollision();
        //Debug.Log(transform.position);

    }

    private void regularMovement(float xValue, float yValue)
    {
        var speed = rolling ? rollPlayerSpeed : playerSpeed;

        var moveDir = new Vector3(xValue, yValue);

        moveDir *= speed;

        transform.position += moveDir;
    }

    private void Roll(InputAction.CallbackContext obj)
    {
        rolling = true;
        Invoke("stopRoll", rollSeconds);
    }

    private void stopRoll()
    {
        rolling = false;
    }

    private void checkCollision()
    {
        Collider2D[] collisions = Physics2D.OverlapBoxAll((Vector2)(body.transform.position + body.transform.localScale / 2), body.transform.localScale, 0);

        foreach (Collider2D collision in collisions)
        {
            if (collision == body) continue;
            
            ColliderDistance2D colliderDistance = collision.Distance(body);
            //Debug.Log((Vector3)(colliderDistance.pointA - colliderDistance.pointB));
            if (colliderDistance.isOverlapped)
            {
                Debug.DrawLine(transform.position, transform.position + (Vector3)(colliderDistance.pointA - colliderDistance.pointB), color);
                transform.localPosition += (Vector3)(colliderDistance.pointA - colliderDistance.pointB);
            }   
        }
    }
}
