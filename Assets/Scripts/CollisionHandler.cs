using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
    [SerializeField] AudioClip explode;
    [SerializeField] AudioClip finish;
    
    [SerializeField] ParticleSystem explosionParticles; 
    [SerializeField] ParticleSystem finishParticles;
    
    private AudioSource audioSource;
    //Variable whether or not our object is in a middle of an action/a method
    private bool isTransitioning = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        //if we have been crashed/ have reached the landing pad, stop processing collisions
        if (isTransitioning) { return; }
        switch (other.gameObject.tag)
        {
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
        //object is doing CrashSequence()
        isTransitioning = true;
        explosionParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(explode);
        isTransitioning = true;
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
        //object is doing NextLevelSequence()
        isTransitioning = true;
        finishParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(finish);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel",waitTime);
    }
}
