using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class WASD_Move : MonoBehaviour
{
    // reduction value to hinder the player's movement
    private float playerSpeedReduction = 0.1F;

    private Vector2 movementInput;

    /*
     * An action reference is created using a feild, it is used to 
     * reference the specific action, more can be added as needed
    */
    [SerializeField] private InputActionReference movement, roll;

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
        movementInput = movement.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // moves 100 times every second
        regularMovement(movementInput.x, movementInput.y);
    }

    private void regularMovement(float xValue, float yValue)
    {
        gameObject.transform.position = new Vector3(
            transform.position.x + (xValue * playerSpeedReduction), 
            transform.position.y + (yValue * playerSpeedReduction)
            );
    }

    private void Roll(InputAction.CallbackContext obj)
    {
      // roll code goes here
    }

}
