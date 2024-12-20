using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // Coin'in d�n�� h�z�
    public GameObject coinTextObject; // 3D Text objesi
    private TextMesh coinTextMesh; // Text bile�eni
    private Renderer coinRenderer; // Coin'in renderer'�

    private float colorChangeSpeed = 2f; // Renk de�i�im h�z�
    private float hueValue = 0f; // Renk tonunu tutacak de�i�ken
	public static int difficulty; // Zorluk seviyesi (0: Normal, 1: Zor)
	public GameObject timerObject; // Zamanlay�c� objesi
	private zamanlayici timer; // Timer scripti

    void Start()
    {
        // coinTextObject bile�eninden TextMesh bile�enini al
        coinTextMesh = coinTextObject.GetComponent<TextMesh>();
        coinRenderer = GetComponent<Renderer>(); // Coin'in Renderer bile�enini al
		timer = timerObject.GetComponent<zamanlayici>(); // Timer scriptini al
		difficulty = PlayerPrefs.GetInt("zorlUK");// Zorluk seviyesini al
		
    }

    void Update()
    {
        // Coin'in kendi ekseni etraf�nda d�nmesini sa�lar
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Coin'in rengini polis �akar� gibi de�i�tirme
        ChangeColorToPoliceLights();
    }

    void OnTriggerEnter(Collider other)
    {
        // Oyuncu coin'e �arpt���nda
        if (other.CompareTag("Player"))
        {
            // Coin'i sahneden kald�r
            Destroy(gameObject);

            // Coin say�s�n� art�r ve g�ncelle
            CoinSpawner spawner = FindObjectOfType<CoinSpawner>(); // CoinSpawner'� bul
            spawner.IncreaseCoinCount(); // Coin say�s�n� art�r
			
			// E�er zorluk seviyesi zorsa zamanlay�c�y� g�ncelle 
			if (difficulty == 1) 
			{ 
				timer.ResetTimer(); // Timer'� s�f�rla 
			}
        }
    }

    void ChangeColorToPoliceLights()
    {
        // Polis �akar� gibi renkleri s�rayla de�i�tirmek i�in hueValue'yu zamanla artt�r
        hueValue += Time.deltaTime * colorChangeSpeed; // Hue'yu zamanla artt�r�yoruz

        if (hueValue > 1f) hueValue = 0f; // Hue de�eri 1'i ge�ti�inde s�f�rlan�r (0-1 aras�nda)

        // HSV'yi RGB'ye �evirip coin'in rengini ayarla
        coinRenderer.material.color = Color.HSVToRGB(hueValue, 1f, 1f);
    }
}
