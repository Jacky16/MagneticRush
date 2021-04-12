using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    Vector2 axisMouseWheel = Vector2.zero;
    [SerializeField] ChargesManager charges;
    Vector2 mousePosition = Vector2.zero;
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
            charges.ChargeSpawn(mousePosition);
            charges.Edit(mousePosition);
        }
    }
    public void OnEditCharge(InputAction.CallbackContext ctx)
    {
        charges.EditMode();
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
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
