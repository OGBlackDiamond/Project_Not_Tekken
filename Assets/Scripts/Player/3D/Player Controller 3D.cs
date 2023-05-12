using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3D : MonoBehaviour
{
    [SerializeField] private float moveSpeed, sensitivity;
    [SerializeField] private InputActionReference movement;

    private Vector2 movementInput;

    // Update is called once per frame
    void Update()
    {
        // refreshes the movement input when not rolling
        movementInput = movement.action.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        // moves 100 times every second
        regularMovement(movementInput.x, movementInput.y);
    }

    private void regularMovement(float xValue, float zValue)
    {
        var moveDir = new Vector3(xValue, 0, zValue);

        moveDir *= moveSpeed;

        transform.position += moveDir;
    }
}
