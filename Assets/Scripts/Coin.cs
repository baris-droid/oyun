using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // Coin'in dönüþ hýzý
    public GameObject coinTextObject; // 3D Text objesi
    private TextMesh coinTextMesh; // Text bileþeni
    private Renderer coinRenderer; // Coin'in renderer'ý

    private float colorChangeSpeed = 2f; // Renk deðiþim hýzý
    private float hueValue = 0f; // Renk tonunu tutacak deðiþken
	public static int difficulty; // Zorluk seviyesi (0: Normal, 1: Zor)
	public GameObject timerObject; // Zamanlayýcý objesi
	private zamanlayici timer; // Timer scripti

    void Start()
    {
        // coinTextObject bileþeninden TextMesh bileþenini al
        coinTextMesh = coinTextObject.GetComponent<TextMesh>();
        coinRenderer = GetComponent<Renderer>(); // Coin'in Renderer bileþenini al
		timer = timerObject.GetComponent<zamanlayici>(); // Timer scriptini al
		difficulty = PlayerPrefs.GetInt("zorlUK");// Zorluk seviyesini al
		
    }

    void Update()
    {
        // Coin'in kendi ekseni etrafýnda dönmesini saðlar
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Coin'in rengini polis çakarý gibi deðiþtirme
        ChangeColorToPoliceLights();
    }

    void OnTriggerEnter(Collider other)
    {
        // Oyuncu coin'e çarptýðýnda
        if (other.CompareTag("Player"))
        {
            // Coin'i sahneden kaldýr
            Destroy(gameObject);

            // Coin sayýsýný artýr ve güncelle
            CoinSpawner spawner = FindObjectOfType<CoinSpawner>(); // CoinSpawner'ý bul
            spawner.IncreaseCoinCount(); // Coin sayýsýný artýr
			
			// Eðer zorluk seviyesi zorsa zamanlayýcýyý güncelle 
			if (difficulty == 1) 
			{ 
				timer.ResetTimer(); // Timer'ý sýfýrla 
			}
        }
    }

    void ChangeColorToPoliceLights()
    {
        // Polis çakarý gibi renkleri sýrayla deðiþtirmek için hueValue'yu zamanla arttýr
        hueValue += Time.deltaTime * colorChangeSpeed; // Hue'yu zamanla arttýrýyoruz

        if (hueValue > 1f) hueValue = 0f; // Hue deðeri 1'i geçtiðinde sýfýrlanýr (0-1 arasýnda)

        // HSV'yi RGB'ye çevirip coin'in rengini ayarla
        coinRenderer.material.color = Color.HSVToRGB(hueValue, 1f, 1f);
    }
}
