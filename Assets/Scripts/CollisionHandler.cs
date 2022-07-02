using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioSource playerVoice;
    private void OnCollisionEnter(Collision collision)
    {
        
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Oh, a friend ^^");
                break;
            case "Finish":
                Debug.Log("Yay, finished!");
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Yummy :p");
                break;
            default:
                Debug.Log("Oopsy Daisy :P");
                StartCrashSequence();
                break;
        }
        
    }

    void StartCrashSequence(){
        GetComponent<Movement>().isAlive = false;
        GetComponent<Movement>().enabled = false;
        StartCoroutine(Example());
        Debug.Log(levelLoadDelay);
        Invoke("ReloadScene", GetComponent<AudioForPlayer>().clipLength);
    }
    IEnumerator Example()
    {
        levelLoadDelay = GetComponent<AudioForPlayer>().clipLength;
        yield return new WaitUntil(() => levelLoadDelay > 0);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            
        SceneManager.LoadScene(currentSceneIndex);
        GetComponent<Movement>().enabled = true;

    }
    void StartSuccessSequence(){
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);

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
