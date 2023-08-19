using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log ("You hit a friendly");
                break;

            case "Finish":
                Debug.Log ("You landed at Finish");
                break;

            case "Fuel":
                Debug.Log ("You picked up fuel");
                break;

            default:
                ReloadLevel();
                break;

        }

        void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
            SceneManager.LoadScene(currentSceneIndex);
        }



    }



}
