using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChargesManager : MonoBehaviour
{
    [SerializeField] GameObject positiveCharge;
    [SerializeField] GameObject negativeCharge;
    [SerializeField] int maxCharges;
    [SerializeField] int numCharges;
    [SerializeField] float selector = 1;
    bool isEditMode;

    //Text
    [SerializeField] TextController text;
    [TextArea]
<<<<<<< Updated upstream
    [SerializeField] string message;
=======
    //[SerializeField] string message;
    int numCharges;
    float selector;
>>>>>>> Stashed changes
    
    void Start()
    {
        maxCharges = numCharges;
    }

    public void ChargeSpawn(Vector3 posSpawn)
    {
        if(numCharges > 0 && numCharges <= maxCharges && !isEditMode)
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
<<<<<<< Updated upstream
            if(!isEditMode)
            text.SetText(message);
=======
            //text.SetText(message);
>>>>>>> Stashed changes
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
}
