using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

 
    public void LoadSettingScene()
    {
        SceneManager.LoadScene("Setting");
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LoadBallScene()
    {
        SceneManager.LoadScene("Ball");
    }

}
