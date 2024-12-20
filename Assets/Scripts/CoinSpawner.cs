using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Coin prefab'ýný burada atayýn
    public Vector2 spawnArea = new Vector2(23f, 53f); // Alan boyutlarý
    public float spawnInterval = 0.5f; // Yarým saniyede bir oluþturma
    public float coinHeight = 5f; // Coin yüksekliði (z ekseninde)
    public GameObject coinTextObject; // Coin sayýsýný gösterecek text objesi
	public GameObject timerObject; // Timer objesi

    private float timer = 0f;
    private int coinCount = 0; // Toplanan coin sayýsý
    private TextMesh coinTextMesh; // TextMesh bileþeni

    void Start()
    {
        // coinTextObject bileþeninden TextMesh bileþenini al
        coinTextMesh = coinTextObject.GetComponent<TextMesh>();
        coinTextMesh.text = "Coins: " + coinCount; // Baþlangýçta coin sayýsýný göster
    }

    void Update()
    {
        // Timer'ý güncelle
        timer += Time.deltaTime;

        // Yarým saniyede bir coin spawn et
        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f; // Timer'ý sýfýrla
        }
    }

    void SpawnCoin()
    {
        // Spawn noktasý belirleyin (x, y) ve z = coinHeight
        float x = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
        float y = Random.Range(-spawnArea.y / 2, spawnArea.y / 2);

        // Coin'i spawn et (z = coinHeight)
        Vector3 spawnPosition = new Vector3(x, coinHeight, y);
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        // Coin'in Coin script'ine coinTextObject referansýný ver
        Coin coinScript = coin.GetComponent<Coin>();
		coinScript.timerObject = timerObject; // Timer objesini atayýn
        coinScript.coinTextObject = coinTextObject;
    }

    public void IncreaseCoinCount()
    {
        // Coin sayýsýný artýr ve text'i güncelle
        coinCount++;
        coinTextMesh.text = "Coins: " + coinCount;
    }
}
