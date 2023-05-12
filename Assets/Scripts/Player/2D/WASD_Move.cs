using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class WASD_Move : MonoBehaviour
{
    // reduction value to hinder the player's movement
    [SerializeField] private float playerSpeed, rollPlayerSpeed, rollSeconds;
    [SerializeField] private InputActionReference movement, roll, slide;

    private Vector2 movementInput;

    private bool rolling;

    /*
     * An action reference is created using a feild, it is used to 
     * reference the specific action, more can be added as needed
    */


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
        // refreshes the movement input all the time
        movementInput = rolling ? movementInput : movement.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // moves 100 times every second
        regularMovement(movementInput.x, movementInput.y);
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
}
