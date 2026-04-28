using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // 어디서든 접근 가능
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = "x" + coinCount;
    }
}