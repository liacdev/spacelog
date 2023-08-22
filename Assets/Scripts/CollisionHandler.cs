using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // PARAMETERS: For tuning, typically set in the editor
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;

    // CACHE: References for readability or speed
    AudioSource audioSource;

    // STATE: Private instance (member) variables

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


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
            // todo add particle effect upon success
            audioSource.PlayOneShot(successSFX);
            GetComponent<Movement>().enabled = false;
            Invoke("LoadNextLevel", levelLoadDelay);

        }


        void StartCrashSequence()
        {
            // todo add particle effect upon crash
            audioSource.PlayOneShot(crashSFX);
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
