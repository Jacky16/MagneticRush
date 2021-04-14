using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject canvasPause;
    [SerializeField] GameObject canvasOptions;
    public static PauseManager singletone;
    bool isPause;
    private void Awake()
    {
        if(singletone == null)
        {
            singletone = this;
        }
    }
    public void Pause()
    {
        isPause = !isPause;
        if (isPause)
        {
            canvasPause.SetActive(true);
            Time.timeScale = 0;           
        }
        else
        {
            Resume();
        }

    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvasOptions.SetActive(false);
        canvasPause.SetActive(false);
        isPause = false;
    }
    public bool GetPause()
    {
        return isPause;
    }
}
