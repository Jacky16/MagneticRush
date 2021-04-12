using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    Vector2 axisMouseWheel = Vector2.zero;
    public void OnWheel(InputAction.CallbackContext ctx)
    {  
        if (ctx.performed)
        {
            axisMouseWheel = ctx.ReadValue<Vector2>();
        }
    }
    public void OnPutCharge(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {

        }
    }
    public void OnDoForce(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {

        }
    }
}
