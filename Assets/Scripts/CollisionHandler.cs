using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Oh, a friend ^^");
                break;
            case "Finish":
                Debug.Log("Yay, finished!");
                LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("Yummy :p");
                break;
            default:
                Debug.Log("Oopsy Daisy :P");
                ReloadScene();
                break;
        }
        void ReloadScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        void LoadNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)//SceneManager.sceneCountInBuildSettings -> Total number of scene
                nextSceneIndex = 0;
            SceneManager.LoadScene(nextSceneIndex);
               
        }
    }
}
