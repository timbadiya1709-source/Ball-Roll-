using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip CoinAudio;           // Assign your coin sound in the inspector
    private AudioSource audioSource;

    void Awake()
    {
        // Try to get or add an AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f; // 3D sound, set to 0 for 2D audio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Play the coin audio
            if (CoinAudio != null && audioSource != null)
            {
                audioSource.PlayOneShot(CoinAudio);
            }
            
            CoinManager.Instance.CoinCollected();

            // Disable mesh/renderer immediately, but destroy/disable the coin after sound is played
            // This way, sound isn't cut off instantly
            GetComponent<Collider>().enabled = false;
            if (TryGetComponent<MeshRenderer>(out var mesh)) mesh.enabled = false;

            // Destroy after audio finishes, or just a small delay if short sound effect.
            Destroy(gameObject, CoinAudio != null ? CoinAudio.length : 0.1f);
        }
    }
}
