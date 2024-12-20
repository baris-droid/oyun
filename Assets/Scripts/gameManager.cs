using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject coinTextObject; // 3D Text objesi
    private TextMesh coinTextMesh;    // Text bileþeni
    private int coinCount = 0;        // Toplanan coin sayýsý

    void Start()
    {
        // 3D Text objesinden TextMesh bileþenini al
        coinTextMesh = coinTextObject.GetComponent<TextMesh>();
        UpdateCoinText();
    }

    public void AddCoin()
    {
        // Coin sayýsýný artýr ve güncelle
        coinCount++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        // TextMesh'e yeni coin sayýsýný yaz
        coinTextMesh.text = "Coins: " + coinCount;
    }
}
