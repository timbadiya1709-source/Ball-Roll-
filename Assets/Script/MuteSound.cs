using UnityEngine;

public class MuteButton : MonoBehaviour
{
    private bool isMuted = false;

    private void Start()
    {
        // Load mute setting when game starts
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplyMuteSetting();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        ApplyMuteSetting();
    }

    private void ApplyMuteSetting()
    {
        AudioListener.volume = isMuted ? 0 : 1;
    }
}
