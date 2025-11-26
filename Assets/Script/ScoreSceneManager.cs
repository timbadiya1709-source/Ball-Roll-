using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSceneManager : MonoBehaviour
{
    public void OnNextButtonClicked()
    {
        int lastLevelIdx = PlayerPrefs.GetInt("LastLevelIndex", 0);
        int nextLevelIdx = lastLevelIdx + 1;

        // Make sure you don't go out of bounds
        if (nextLevelIdx < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIdx);
        }
        else
        {
            Debug.Log("Game completed! No more levels.");
            // Optionally, go to main menu or finish screen
        }
    }
}
