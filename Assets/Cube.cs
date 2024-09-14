using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{

    PlayerControls controls;

    void Awake()
    {

        controls = new PlayerControls();

        controls.Gameplay.Left.performed += ctx => Grow();

    }


    void Grow()
    {
        Debug.Log("its working yay");
    }


    void OnEnable ()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
