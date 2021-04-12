using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float radius;
    [SerializeField] float force;
    [SerializeField] Color positiveColor;
    [SerializeField] Color negativeColor;

    [SerializeField]enum POLESTATE {POSITIVE,NEGATIVE};
    [SerializeField] POLESTATE poleState;
    bool playerInRadius;
    Vector2 dir = Vector2.zero;
    SpriteRenderer spriteRenderer;
    //Player references
    GameObject playerGameObject;
    Transform playerTransform;
    Rigidbody2D rb2dPlayer;
    private void Awake()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerGameObject.transform;
        rb2dPlayer = playerGameObject.GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        ChangeColor();
    }

    private void Update()
    {
        playerInRadius = Vector2.Distance(transform.position, playerTransform.position) < radius;
    }
    private void FixedUpdate()
    {
        MovementPoles();
    }

    private void ChangeColor()
    {
        switch (poleState)
        {
            case POLESTATE.POSITIVE:
                spriteRenderer.color = positiveColor;
                break;

            case POLESTATE.NEGATIVE:
                spriteRenderer.color = negativeColor;
                break;
            default:

                break;
        }
    }
    private void MovementPoles()
    {
        ChangeColor();
        if (playerInRadius)
        {     
            switch (poleState)
            {
                //ROJO
                case POLESTATE.POSITIVE:
                    dir = (playerTransform.position - transform.position).normalized;
                    break;
                //AZUL
                case POLESTATE.NEGATIVE:
                    dir = (transform.position - playerTransform.position).normalized;
                    break;
                default:
                    break;
            }
            rb2dPlayer.AddForceAtPosition(dir * force, playerTransform.position, ForceMode2D.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    
}
