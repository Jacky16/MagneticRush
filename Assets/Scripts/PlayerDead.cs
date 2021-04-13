using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] float distanceToCamera = 14;
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, Camera.main.transform.position);
        if(distance >= distanceToCamera)
        {
            Reboot.singletone.RebootScene();
        }
    }
}
