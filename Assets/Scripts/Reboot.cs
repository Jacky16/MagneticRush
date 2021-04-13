using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reboot : MonoBehaviour
{
    public static Reboot singletone;
    private void Awake()
    {
        if(singletone == null)
        singletone = this;
    }
    public void RebootScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
