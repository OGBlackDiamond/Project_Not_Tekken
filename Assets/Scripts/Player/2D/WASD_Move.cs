using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WASD_Move : MonoBehaviour
{
    //[SerializeField] InputActionAsset actionAsset;

    private float playerSpeed = 0.01F;
    private float playerSpeedNormal = 1F;
    private float velocityX = 0F; 
    private float velocityY = 0F;

    private float xAxis;
    private float yAxis;

    private int time = 0;
    private int initialTime = 0;

    private void Update()
    {
        yAxis = Input.GetAxisRaw("Vertical");
        xAxis = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyUp(KeyCode.Space))
        {
            initialTime = time;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time++;
        regularMovement();
        roll();
    }

    private void regularMovement()
    {
        gameObject.transform.position = new Vector3(transform.position.x + (xAxis * playerSpeedNormal), transform.position.y + (yAxis * playerSpeedNormal));

    }

    private void roll()
    {
        if (time < initialTime + 25) 
        {
            playerSpeedNormal = 2;
        }
        else
        {
            playerSpeedNormal = 1;
        }
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
