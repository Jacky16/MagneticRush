using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    Vector2 axisMouseWheel = Vector2.zero;
    [SerializeField] ChargesManager charges;
    [SerializeField] Vector2 mousePosition = Vector2.zero;
    public void OnWheel(InputAction.CallbackContext ctx)
    {  
        if (ctx.performed)
        {
            axisMouseWheel = ctx.ReadValue<Vector2>();
            charges.SetSelector(axisMouseWheel.y);
        }
    }
    public void OnPutCharge(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            charges.ChargeSpawn(mousePosition);
        }
    }
    public void OnDoForce(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            
        }
    }
    public void OnMouseMovement(InputAction.CallbackContext ctx)
    {
        mousePosition = ctx.ReadValue<Vector2>();
    }
}
