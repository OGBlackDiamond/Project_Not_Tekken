using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3D : MonoBehaviour
{
    // allows the move speed a sensitivity to be changed 
    [SerializeField] private float moveSpeed, sensitivity, gravity;

    // allows for the input of the movement and camera action references
    [SerializeField] private InputActionReference movement, veiwAdjustment;

    [SerializeField] private Transform cam;

    // defines a vector to store the current movement direction
    private Vector3 movementDirection;

    // defines a variable to store the mouse input
    private Vector2 cameraRotaton = Vector2.zero;

    // defines a variable used to store the movement input
    private Vector2 movementInput;

    // defines a rigidbody
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // refreshes the movement input when not rolling
        movementInput = movement.action.ReadValue<Vector2>();
        // gets camera control values from the mouse
        cameraRotaton += veiwAdjustment.action.ReadValue<Vector2>() * sensitivity;
        // makes sure the camera won't bend over backwards
        cameraRotaton.y = Mathf.Clamp(cameraRotaton.y, -90F, 90F);
    }
    void FixedUpdate()
    {
        // moves 100 times every second
        regularMovement(movementInput.x, movementInput.y);
        cameraAdjustment();
    }


    private void regularMovement(float xValue, float zValue)
    {
        // indentifies the player's movement direction based on where the player is facing
        movementDirection = cam.transform.forward * zValue + cam.transform.right * xValue;
        // moves the player twards the given direction
        body.transform.position = body.transform.position + movementDirection.normalized * moveSpeed;
        body.transform.position = body.transform.position - new Vector3(0, gravity, 0);
    }

    private void cameraAdjustment()
    {
        // defines the angles for rotation given by the mouse
        var xQuat = Quaternion.AngleAxis(
            cameraRotaton.x,
            Vector3.up
        );
        var yQuat = Quaternion.AngleAxis(
            cameraRotaton.y,
            Vector3.left
        );

        // rotates the body
        cam.transform.localRotation = xQuat * yQuat;
    }
}
