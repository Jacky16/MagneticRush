using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInCam : MonoBehaviour
{
    Transform player;
    [SerializeField] Vector2 limits;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(transform.position.x - limits.x > player.position.x)
        {
            Debug.Log("Se ha salido");
        }
    }
}
