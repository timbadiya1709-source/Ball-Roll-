using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneHistory
{
    public static string PreviousScene;
}

public class PauseButton : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // Save the current scene before switching
        SceneHistory.PreviousScene = SceneManager.GetActiveScene().name;
        
        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }
}
