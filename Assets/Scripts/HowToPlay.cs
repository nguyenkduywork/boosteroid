using UnityEngine;


public class HowToPlay : MonoBehaviour
{
    private Canvas thisCanvas;
    public Menu main;
    private void Start()
    {
        thisCanvas = GetComponent<Canvas>();
      
    }

    public void OnReturnButton()
    {
        thisCanvas.enabled = false;
        main.Enable();
    }

    public void Enable()
    {
        thisCanvas.enabled = true;
    }

    
}