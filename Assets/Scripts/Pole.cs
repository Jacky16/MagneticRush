using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] Vector2 boxSize;
    [SerializeField] float force;
    [SerializeField] Color positiveColor;
    [SerializeField] Color negativeColor;
    [SerializeField]enum POLESTATE {POSITIVE,NEGATIVE};
    [SerializeField] POLESTATE poleState;

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
    private void FixedUpdate()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        Collider2D[] colls2D = Physics2D.OverlapBoxAll(transform.position, boxSize, 0);
        if (colls2D != null)
        {
            foreach (Collider2D col2d in colls2D)
            {
                if (col2d.CompareTag("Player"))
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
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    
}
