using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Canvas main;
    public HowToPlay howTo;

    private void Start()
    {
        main = GetComponent<Canvas>();
        
    }

    private void OnPlayButton ()
    {
        SceneManager.LoadScene(1);
    }
    private void OnQuitButton ()
    {
        Application.Quit();
    }

    private void OnHowToButton ()
    {
        main.enabled = false;
        howTo.Enable();
    }

    public void Enable()
    {
        main.enabled = true;
    }
}
