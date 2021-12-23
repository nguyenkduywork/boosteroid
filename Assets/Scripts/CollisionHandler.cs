using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Fuel picked up");
                break;
            case "Finish":
                Debug.Log("Finished!");
                break;
            case "Obstacle":
                Debug.Log("You touched an obstacle!!");
                break;
            default:
                Debug.Log("This thing you touched isn't dangerous");
                break;
        }
    }
}
