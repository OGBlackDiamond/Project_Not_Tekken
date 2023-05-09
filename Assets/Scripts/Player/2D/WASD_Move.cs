using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Move : MonoBehaviour
{

    private float playerSpeed = 0.1F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + playerSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(transform.position.x - playerSpeed, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - playerSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(transform.position.x + playerSpeed, transform.position.y);
        }
    }
}
