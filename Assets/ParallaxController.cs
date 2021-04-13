using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D prb2d;
    private Transform ptrans;
    // Start is called before the first frame update
    void Start()
    {
        prb2d = GetComponent<Rigidbody2D>();
        ptrans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        prb2d.velocity = -transform.right * speed;

        if(transform.position.x <= -24)
        {
            transform.position = new Vector3(53, transform.position.y, transform.position.z);
        }
    }
}
