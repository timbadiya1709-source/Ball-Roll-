using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPadTrigger : MonoBehaviour
{
    public AudioClip finishAudio;      // Assign this in the inspector
    private AudioSource audioSource;   // Internal reference

    void Awake()
    {
        // Add or get AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If *this* is the finish pad, check if "Ball" collided, else swap logic accordingly
        if (other.CompareTag("FinishPad"))
        {
            PlayFinishAudioAndLoadScene();
        }
    }

    void PlayFinishAudioAndLoadScene()
    {
        // Play finish audio immediately without waiting
        if (audioSource != null && finishAudio != null)
        {
            audioSource.PlayOneShot(finishAudio);
        }
        
        // Load scene instantly
        LoadScoreScene();
    }

    void LoadScoreScene()
    {
        int currentLevelIdx = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastLevelIndex", currentLevelIdx);
        SceneManager.LoadScene("ScoreScene");
    }
}
