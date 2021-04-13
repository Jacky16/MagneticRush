using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutoText : MonoBehaviour
{
    [SerializeField] TextController text;
    [TextArea]
    [SerializeField] string message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            text.SetText(message);
        }
    }
}
