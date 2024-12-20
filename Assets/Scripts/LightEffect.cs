using UnityEngine;

public class LightEffect : MonoBehaviour
{
    public Light lightSource; // I��k kayna��n�z
    public float intensitySpeed = 1f; // Yo�unlu�un art��/azal�� h�z�
    public float colorChangeSpeed = 1f; // Renk de�i�im h�z�

    private float targetIntensity;
    private Color targetColor;

    void Start()
    {
        if (lightSource == null)
            lightSource = GetComponent<Light>(); // E�er ���k kayna�� atanmad�ysa, bu GameObject'in �����n� al
    }

    void Update()
    {
        // I��k yo�unlu�unu de�i�tirme
        targetIntensity = Mathf.PingPong(Time.time * intensitySpeed, 1f); // Yo�unluk zamanla art�p azalacak
        lightSource.intensity = targetIntensity;

        // Renk de�i�imi
        targetColor = new Color(Mathf.PingPong(Time.time * colorChangeSpeed, 1f),
                                 Mathf.PingPong(Time.time * colorChangeSpeed + 0.5f, 1f),
                                 Mathf.PingPong(Time.time * colorChangeSpeed + 1f, 1f));
        lightSource.color = targetColor; // Rengi de�i�tirme
    }
}
