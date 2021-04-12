using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChargesManager : MonoBehaviour
{
    [SerializeField] GameObject positiveCharge;
    [SerializeField] GameObject negativeCharge;
    [SerializeField] int maxCharges;
    [SerializeField] TextController text;
    [TextArea]
    [SerializeField] string message;
    [SerializeField] int numCharges;
    [SerializeField] float selector = 1;
    
    void Start()
    {
        maxCharges = numCharges;
    }

    public void ChargeSpawn(Vector3 posSpawn)
    {
        if(numCharges > 0 && numCharges <= maxCharges)
        {
            if (selector == 1)
            {
                Instantiate(positiveCharge, posSpawn, Quaternion.identity, null);
                numCharges--;
            }
            else if (selector == -1)
            {
                Instantiate(negativeCharge, posSpawn, Quaternion.identity, null);
                numCharges--;
            }
        }
        else
        {
            text.SetText(message);
        }
    }

    public void SetSelector(float _selector)
    {
        selector = _selector;
    }
}
