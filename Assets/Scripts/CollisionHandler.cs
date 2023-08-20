using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log ("You hit a friendly");
                break;

            case "Finish":
                StartSuccessSequence();
                break;

            // case "Fuel":
            //     Debug.Log ("You picked up fuel");
            //     break;

            default:
                // ReloadLevel();
                StartCrashSequence();
                break;

        }
    }
    
        void StartSuccessSequence()
        {
            // todo add sfx upon success
            // todo add particle effect upon success
            GetComponent<Movement>().enabled = false;
            Invoke("LoadNextLevel", levelLoadDelay);

        }


        void StartCrashSequence()
        {
            // todo add sfx upon crash
            // todo add particle effect upon crash
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", levelLoadDelay);

        }

        void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
            SceneManager.LoadScene(currentSceneIndex);
        }

        void LoadNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            
            SceneManager.LoadScene(nextSceneIndex);

        }

}
