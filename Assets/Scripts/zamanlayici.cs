using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro kütüphanesini ekleyin

public class zamanlayici : MonoBehaviour
{
    public float startTime = 30f; // Başlangıç zamanı
    private float timeLeft; // Kalan zaman
    public TextMeshProUGUI timerText; // TextMeshPro bileşeni

    void Start()
    {
        timeLeft = startTime; // Zamanı başlangıç değeri olarak ayarla
        UpdateTimerText(); // Timer textini güncelle
    }

    void Update()
    {
        if (Coin.difficulty == 1)
        {
            timeLeft -= Time.deltaTime; // Zamanı azalt

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                GameOver(); // Zaman bittiğinde oyun bitirme fonksiyonunu çağır
            }

            UpdateTimerText(); // Timer textini güncelle
        }
    }

    public void ResetTimer()
    {
        timeLeft = startTime; // Zamanı sıfırla
        UpdateTimerText(); // Timer textini güncelle
    }

    void UpdateTimerText()
    {
        timerText.text = "KALAN SURE: " + Mathf.Round(timeLeft).ToString(); // Timer textini güncelle
    }

    void GameOver()
    {
        // Oyunu bitirme işlemleri
        Debug.Log("Game Over!");
    }
}
