using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChargesManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject positiveCharge;
    [SerializeField] GameObject negativeCharge;
    [Header("General Settings")]
    [SerializeField] int numCharges;
    [SerializeField] float mouseForce;
    [SerializeField] float mouseRadius;
    int maxCharges;
    float selector = 1;
    bool isEditMode;
    bool isDoingForce;
    bool playerInRadius;
    Vector2 dir = Vector2.zero;
    [Header("Text")]
    [SerializeField] TextController text;
    [TextArea]
    [SerializeField] string message;

    [Header("Mouse Visual Settings")]
    [SerializeField] Transform mouseTransform;
    [SerializeField] SpriteRenderer spr;
    [SerializeField] ParticleSystem [] particlesForce;
    [SerializeField] Color positiveColor;
    [SerializeField] Color negativeColor;
    [SerializeField] Color neutralColor;

    Rigidbody2D rb2dPlayer;
    Vector2 mousePos;
    private void Awake()
    {
        rb2dPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        maxCharges = numCharges;
        Cursor.visible = false;
    }
    private void Update()
    {
        mousePos = InputManager.singletone.GetMousePos();
        isDoingForce = InputManager.singletone.GetIsDoingForce();
        playerInRadius = Vector2.Distance(mousePos, rb2dPlayer.position) < mouseRadius;
        mouseTransform.position = mousePos;

        ChangeMouseColor();
        DoForce();
        RotationWeapon();

        if (!isDoingForce)
        {
            PlayParticlesForce();
        }     
        print(isDoingForce);
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
    public void SetSelector(float _selector)
    {
        selector = _selector;
    }
    public void DoForce()
    {
        if (isDoingForce && playerInRadius)
        {
            dir = (rb2dPlayer.position - mousePos).normalized;
            rb2dPlayer.AddForceAtPosition(dir * mouseForce, rb2dPlayer.position, ForceMode2D.Force);
        }    
    }
    public void ChangeMouseColor()
    {
        if (isDoingForce)
        {
            spr.color = neutralColor;
        }
        else
        {
            if(selector == 1)
            {
                spr.color = positiveColor;
            }else if(selector == -1)
            {
                spr.color = negativeColor;
            }
        }
    }
    public void RotationWeapon()
    {
        Vector2 dirRot = mousePos - rb2dPlayer.position;
        float rotationZ = Mathf.Atan2(dirRot.y, dirRot.x) * Mathf.Rad2Deg;
        mouseTransform.localRotation = Quaternion.Euler(0, 0, rotationZ + 90);
    }

    void PlayParticlesForce()
    {
        for(int i = 0; i< particlesForce.Length; i++)
        {
            particlesForce[i].Play();
        }
        Debug.Log("AHHH");
    }
    void StopParticlesForce()
    {

        foreach (ParticleSystem ps in particlesForce)
        {
            ps.Stop();
        }
    }
}
