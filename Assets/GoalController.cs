using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Animator animFade;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Invoke("LoadScene", 1);
            animFade.SetTrigger("FadeOut");
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
