using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reboot : MonoBehaviour
{
    [SerializeField] int nScene;
    public void RebootScene()
    {
        SceneManager.LoadScene(nScene);
    }
}
