using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChargesManager : MonoBehaviour
{
    [SerializeField] GameObject positiveCharge;
    [SerializeField] GameObject negativeCharge;
    int maxCharges;
    [SerializeField] int numCharges;
    float selector = 1;
    bool isEditMode;

    //Text
    [SerializeField] TextController text;
    [TextArea]
    [SerializeField] string message;

    [Header("Mouse Visual Settings")]
    [SerializeField] Transform mouseTransform;
    [SerializeField] ParticleSystem ps;
    [SerializeField] SpriteRenderer spr;
    [SerializeField] Color positiveColor;
    [SerializeField] Color negativeColor;


    void Start()
    {
        maxCharges = numCharges;
        Cursor.visible = false;
    }
    private void Update()
    {
        mouseTransform.position = InputManager.singletone.GetMousePos();
        ChangeMouseColor();
    }
    public void ChargeSpawn(Vector3 posSpawn)
    {
        if(numCharges > 0 && numCharges <= maxCharges && !isEditMode)
        {         
            SimpleCameraShakeInCinemachine.singletone.DoCameraShake();
            numCharges--;
            if (selector == 1)
            {
                Instantiate(positiveCharge, posSpawn, Quaternion.identity, null);              
            }
            else if (selector == -1)
            {
                Instantiate(negativeCharge, posSpawn, Quaternion.identity, null);             
            }
        }
        else
        {
            if(!isEditMode)
            text.SetText(message);
        }
       
    }
    public void Edit(Vector2 raySpawn)
    {
        if (isEditMode)
        {
            RaycastHit2D hit = Physics2D.Raycast(raySpawn, Vector3.forward);
            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("Particle"))
                {
                    numCharges++;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    public void EditMode()
    {
        isEditMode = !isEditMode;
    }
    public void SetSelector(float _selector)
    {
        selector = _selector;
    }

    public void ChangeMouseColor()
    {
        if(selector == 1)
        {
            ps.startColor = positiveColor;
            spr.color = positiveColor;
        }else if(selector == -1)
        {
            ps.startColor = negativeColor;
            spr.color = negativeColor;
        }
    }

    public float GetSelector()
    {
        return selector;
    }
}
