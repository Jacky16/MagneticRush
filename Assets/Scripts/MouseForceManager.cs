using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseForceManager : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float radius;
    [SerializeField] float force;
    [SerializeField] enum POLESTATE { POSITIVE, NEGATIVE };
    [SerializeField] POLESTATE poleState;

    bool mousePressed;
    bool playerInRadius;
    float selector = 1;
    Vector2 dir = Vector2.zero;

    //Player references
    GameObject playerGameObject;
    Transform playerTransform;
    Rigidbody2D rb2dPlayer;
    Vector3 mousePos = Vector2.zero;
    private void Awake()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerGameObject.transform;
        rb2dPlayer = playerGameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        mousePos = InputManager.singletone.GetMousePos();
        //mousePos = Camera.main.WorldToScreenPoint(mousePos);
        playerInRadius = Vector2.Distance(mousePos, playerTransform.position) < radius;     
    }
    private void FixedUpdate()
    {
        if (mousePressed && playerInRadius)
        {
            switch (poleState)
            {
                //ROJO
                case POLESTATE.POSITIVE:
                    dir = (playerTransform.position - mousePos).normalized;
                    break;
                //AZUL
                case POLESTATE.NEGATIVE:
                    dir = (mousePos - playerTransform.position).normalized;
                    break;
                default:
                    break;
            }
            rb2dPlayer.AddForceAtPosition(dir * force, playerTransform.position, ForceMode2D.Force);
        }
    }
    void ChangeSelector()
    {
        //POSITIVO(ROJO)
        if(selector == 1)
        {
            poleState = POLESTATE.POSITIVE;
        
        }
        //NEGATIVO(AZUL)
        else if(selector == -1)
        {
            poleState = POLESTATE.NEGATIVE;
        }
    }

    public void SetSelector(float _selector)
    {
        selector = _selector;
        ChangeSelector();
    }
    public void SetMousePressed(bool _b)
    {
        mousePressed = _b;
    }

    private void OnDrawGizmos()
    {
        if(InputManager.singletone != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(InputManager.singletone.GetMousePos(), radius);
        }
    }
}
