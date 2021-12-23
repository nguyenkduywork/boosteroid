using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
    [SerializeField] AudioClip explode;
    [SerializeField] AudioClip finish;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Fuel picked up");
                break;
            case "Finish":
                NextLevelSequence();
                break;
            case "Obstacle":
                CrashSequence();
                break;
            default:
                Debug.Log("This thing you touched isn't dangerous");
                break;
        }
    }

    void CrashSequence()
    {
        
        audioSource.PlayOneShot(explode);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", waitTime);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void NextLevelSequence()
    {
        audioSource.PlayOneShot(finish);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel",waitTime);
    }
}
