using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WASD_Move : MonoBehaviour
{
    //[SerializeField] InputActionAsset actionAsset;

    private float playerSpeed = 0.001F;
    private float velocityX = 0F; 
    private float velocityY = 0F;


    // Update is called once per frame
    void Update()
    {
        slipperyMovement();
    }

    private void slipperyMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velocityY += playerSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocityY -= playerSpeed;
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
        if (Input.GetKey(KeyCode.A))
        {
            velocityX -= playerSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocityX += playerSpeed;
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
