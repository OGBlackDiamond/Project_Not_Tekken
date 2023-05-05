using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private GameObject camera3D;
    [SerializeField] private GameObject camera2D;

    private bool state = false;

    public void ChangeCamera()
    {
        camera3D.SetActive(!state);
        camera2D.SetActive(state);
        Debug.Log(state ? "2D" : "3D");
        state = !state;
    }
}
