
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void LoadPreviousScene()
    {
        if (!string.IsNullOrEmpty(SceneHistory.PreviousScene))
        {
            SceneManager.LoadScene(SceneHistory.PreviousScene);
        }
        else
        {
            Debug.LogWarning("No previous scene stored!");
        }
    }
}
