using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{

    private mover mover;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<mover>();
    }
    void FixedUpdate()
    {
        mover.done = false;
    }

    public void OnMoveLeft(CallbackContext context)
    {
        mover.SetInputFloatLeft(context.ReadValue<float>());
        
    }

    public void OnMoveRight(CallbackContext context)
    {
        mover.SetInputFloatRight(context.ReadValue<float>());

    }

    public void OnMoveUp(CallbackContext context)
    {
        mover.SetInputFloatUp(context.ReadValue<float>());

    }

    public void OnMoveDown(CallbackContext context)
    {
        mover.SetInputFloatDown(context.ReadValue<float>());

    }

}
