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

    [SerializeField]enum DIRECTION { UP,DOWN,LEFT,RIGHT,ALL_DIRECTIONS};
    [SerializeField] DIRECTION directions;
    [Header("Audios Settings")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioNegative;
    [SerializeField] AudioClip audioPositive;
    float timeToStopAudio = 2;
    float count = 0;
    bool hasPlayed;

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
                    count = 0;
                    switch (poleState)
                    {
                        //ROJO
                         
                        case POLESTATE.POSITIVE:
                            //Reproducir Audio
                            if (!audioSource.isPlaying)
                            {
                                audioSource.PlayOneShot(audioNegative);
                            }
                            switch (directions)
                            {
                                case DIRECTION.UP:
                                    dir = Vector2.up * force;
                                    break;

                                case DIRECTION.DOWN:
                                    dir = Vector2.down * force;
                                    break;

                                case DIRECTION.LEFT:
                                    dir = Vector2.left * force;
                                    break;
                                case DIRECTION.RIGHT:
                                    dir = Vector2.right * force;
                                    break;

                                case DIRECTION.ALL_DIRECTIONS:
                                    dir = (playerTransform.position - transform.position).normalized;
                                    break;
                            }
                            break;

                        case POLESTATE.NEGATIVE:
                            //Reproducir Audio
                            if (!audioSource.isPlaying)
                            {
                                audioSource.PlayOneShot(audioPositive);
                            }

                            dir = (transform.position - playerTransform.position).normalized;
                            break;
                    }
                    rb2dPlayer.AddForceAtPosition(dir * force, playerTransform.position, ForceMode2D.Force);

                }
                else
                {
                    count += Time.fixedDeltaTime;
                    if(count >= timeToStopAudio)
                    {
                        audioSource.Stop();
                    }
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
