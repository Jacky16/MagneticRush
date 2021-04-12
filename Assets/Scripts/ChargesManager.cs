using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargesManager : MonoBehaviour
{
    [SerializeField] GameObject positiveCharge;
    [SerializeField] GameObject negativeCharge;
    [SerializeField] int maxCharges;
    int numCharges;
    float selector;
    
    // Start is called before the first frame update
    void Start()
    {
        selector = 0;
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
            /*Poner mensaje en un canvas de: "Ya has colocado el máximo de partículas posibles
             Si quieres colocar más, borra alguna de las actuales" (más cortito).*/
        }
    }

    public void SetSelector(float _selector)
    {
        selector = _selector;
    }
}
