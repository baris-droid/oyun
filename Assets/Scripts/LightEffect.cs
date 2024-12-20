using UnityEngine;

public class LightEffect : MonoBehaviour
{
    public Light lightSource; // Iþýk kaynaðýnýz
    public float intensitySpeed = 1f; // Yoðunluðun artýþ/azalýþ hýzý
    public float colorChangeSpeed = 1f; // Renk deðiþim hýzý

    private float targetIntensity;
    private Color targetColor;

    void Start()
    {
        if (lightSource == null)
            lightSource = GetComponent<Light>(); // Eðer ýþýk kaynaðý atanmadýysa, bu GameObject'in ýþýðýný al
    }

    void Update()
    {
        // Iþýk yoðunluðunu deðiþtirme
        targetIntensity = Mathf.PingPong(Time.time * intensitySpeed, 1f); // Yoðunluk zamanla artýp azalacak
        lightSource.intensity = targetIntensity;

        // Renk deðiþimi
        targetColor = new Color(Mathf.PingPong(Time.time * colorChangeSpeed, 1f),
                                 Mathf.PingPong(Time.time * colorChangeSpeed + 0.5f, 1f),
                                 Mathf.PingPong(Time.time * colorChangeSpeed + 1f, 1f));
        lightSource.color = targetColor; // Rengi deðiþtirme
    }
}
