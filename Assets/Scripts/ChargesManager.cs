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
    int numCharges;
    float selector;
    
    // Start is called before the first frame update
    void Start()
    {
        selector = 0;
        numCharges = 5;
        ChargeSpawn(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ChargeSpawn(Vector3 posSpawn)
    {
        if(numCharges <= maxCharges)
        {
            if (selector == 1)
            {
                Instantiate(positiveCharge, posSpawn, Quaternion.identity, null);
                numCharges++;
            }
            else if (selector == -1)
            {
                Instantiate(negativeCharge, posSpawn, Quaternion.identity, null);
                numCharges++;
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
