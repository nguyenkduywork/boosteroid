using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
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
        //TODO add SFX when crashed, particle effect too
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
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel",waitTime);
    }
}
