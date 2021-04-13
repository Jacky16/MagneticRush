using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChargesManager : MonoBehaviour
{
    [SerializeField] GameObject positiveCharge;
    int maxCharges;
    [SerializeField] int numCharges;
    [SerializeField] float selector = 1;
    bool isEditMode;

    //Text
    [SerializeField] TextController text;
    [TextArea]
    [SerializeField] string message;

    
    void Start()
    {
        maxCharges = numCharges;
    }

    public void ChargeSpawn(Vector3 posSpawn)
    {
        if(numCharges > 0 && numCharges <= maxCharges && !isEditMode)
        {
            Instantiate(positiveCharge, posSpawn, Quaternion.identity, null);
            SimpleCameraShakeInCinemachine.singletone.DoCameraShake();
            numCharges--;
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
    public float GetSelector()
    {
        return selector;
    }
}
