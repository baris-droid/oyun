using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject coinTextObject; // 3D Text objesi
    private TextMesh coinTextMesh;    // Text bile�eni
    private int coinCount = 0;        // Toplanan coin say�s�

    void Start()
    {
        // 3D Text objesinden TextMesh bile�enini al
        coinTextMesh = coinTextObject.GetComponent<TextMesh>();
        UpdateCoinText();
    }

    public void AddCoin()
    {
        // Coin say�s�n� art�r ve g�ncelle
        coinCount++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        // TextMesh'e yeni coin say�s�n� yaz
        coinTextMesh.text = "Coins: " + coinCount;
    }
}
