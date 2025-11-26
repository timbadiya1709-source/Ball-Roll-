using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public Image[] coinImages; // Assign these in the inspector (3 only)

    private int coinsCollected = 0;
    private int totalCoins = 3;

    void Awake()
    {
        Instance = this;
        // Hide all coin UI at start
        foreach (Image img in coinImages)
            img.enabled = false;
        coinsCollected = 0;
    }

    public void CoinCollected()
    {
        if (coinsCollected < totalCoins)
        {
            coinImages[coinsCollected].enabled = true; // Show coin image
            coinsCollected++;
        }
    }
}
