using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    TextMeshProUGUI text;
    float counter;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(text.text != "")
        {
            counter += Time.deltaTime;
            if(counter >= 3)
            {
                text.text = "";
                counter = 0;
            }
        }
    }

    public void SetText(string _text)
    {
        text.text = _text;
    }
}
