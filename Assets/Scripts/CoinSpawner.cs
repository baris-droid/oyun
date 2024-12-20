using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Coin prefab'�n� burada atay�n
    public Vector2 spawnArea = new Vector2(23f, 53f); // Alan boyutlar�
    public float spawnInterval = 0.5f; // Yar�m saniyede bir olu�turma
    public float coinHeight = 5f; // Coin y�ksekli�i (z ekseninde)
    public GameObject coinTextObject; // Coin say�s�n� g�sterecek text objesi
	public GameObject timerObject; // Timer objesi

    private float timer = 0f;
    private int coinCount = 0; // Toplanan coin say�s�
    private TextMesh coinTextMesh; // TextMesh bile�eni

    void Start()
    {
        // coinTextObject bile�eninden TextMesh bile�enini al
        coinTextMesh = coinTextObject.GetComponent<TextMesh>();
        coinTextMesh.text = "Coins: " + coinCount; // Ba�lang��ta coin say�s�n� g�ster
    }

    void Update()
    {
        // Timer'� g�ncelle
        timer += Time.deltaTime;

        // Yar�m saniyede bir coin spawn et
        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f; // Timer'� s�f�rla
        }
    }

    void SpawnCoin()
    {
        // Spawn noktas� belirleyin (x, y) ve z = coinHeight
        float x = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
        float y = Random.Range(-spawnArea.y / 2, spawnArea.y / 2);

        // Coin'i spawn et (z = coinHeight)
        Vector3 spawnPosition = new Vector3(x, coinHeight, y);
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        // Coin'in Coin script'ine coinTextObject referans�n� ver
        Coin coinScript = coin.GetComponent<Coin>();
		coinScript.timerObject = timerObject; // Timer objesini atay�n
        coinScript.coinTextObject = coinTextObject;
    }

    public void IncreaseCoinCount()
    {
        // Coin say�s�n� art�r ve text'i g�ncelle
        coinCount++;
        coinTextMesh.text = "Coins: " + coinCount;
    }
}
