using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIStartManager : MonoBehaviour
{
    public GameObject[] buttonsToHide; // Assign your 4 buttons here
    public GameObject ballController;   // Your ball controller script or object
    public AudioClip clickSound;        // Assign this in the inspector
    private AudioSource audioSource;    // Private reference
    private bool gameStarted = false;

    void Awake()
    {
        // Get or add AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (gameStarted) return;

        // Mouse input (Editor or PC)
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                HideButtonsAndStartGame();
            }
        }

        // Touch input (Mobile)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    HideButtonsAndStartGame();
                }
            }
        }
    }

    void HideButtonsAndStartGame()
    {
        // Play click sound
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        foreach (GameObject btn in buttonsToHide)
        {
            btn.SetActive(false);
        }

        // Enable the ball's movement or start logic here
        if (ballController != null)
        {
            ballController.GetComponent<GyroBallController>().isGameStarted = true;
        }

        gameStarted = true;
    }
}
