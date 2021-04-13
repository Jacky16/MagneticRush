using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] float velocity;
    private Rigidbody2D prb2d;
    enum DIRECTION { UP, DOWN};
    [SerializeField] private DIRECTION dir;
    // Start is called before the first frame update
    void Start()
    {
        prb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        switch (dir)
        {
            case DIRECTION.UP:
                prb2d.velocity = -transform.up * velocity;
                break;
            case DIRECTION.DOWN:
                prb2d.velocity = transform.up * velocity;
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Waypoint")
        {
            velocity = -velocity;
        }
    }
}
