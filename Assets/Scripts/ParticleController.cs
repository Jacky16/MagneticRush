using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] bool charge; //If true, positive, if false, negative.
    private SpriteRenderer spr;
    [SerializeField] Color negativeColor;
    [SerializeField] Color positiveColor;
    private Rigidbody2D prb2d;
    // Start is called before the first frame update

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetChargeState()
    {
        return charge;
    }

    public void SetChargeState(bool state)
    {
        charge = state;
    }

    public void SetColor(bool charge)
    {
        if (charge)
        {
            spr.color = positiveColor;
        }
        else
        {
            spr.color = negativeColor;
        }
    }
}
