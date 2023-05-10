using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WASD_Move : MonoBehaviour
{
    //[SerializeField] InputActionAsset actionAsset;

    private float playerSpeed = 0.01F;
    private float velocityX = 0F; 
    private float velocityY = 0F;

    private float xAxis;
    private float yAxis;

    private void Update()
    {
        yAxis = Input.GetAxisRaw("Vertical");
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        slipperyMovement();
    }

    private void slipperyMovement()
    {
        
        if (yAxis != 0) 
        {
            velocityY += yAxis * playerSpeed;
        }
        else
        {
            if (velocityY < 0)
            {
                velocityY += 0.0005F;
            }
            if (velocityY > 0)
            {
                velocityY -= 0.0005F;
            }
        }
        if (xAxis != 0)
        {
            velocityX += xAxis * playerSpeed;
        }
        else
        {
            if (velocityX < 0)
            {
                velocityX += 0.0005F;
            }
            if (velocityX > 0)
            {
                velocityX -= 0.0005F;
            }
        }

        gameObject.transform.position = new Vector3(transform.position.x + velocityX, transform.position.y + velocityY);

    }
}
