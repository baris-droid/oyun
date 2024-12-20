using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
	
	public GameObject oyna;
	public GameObject mEnu;
	public GameObject ayarlar;
	public GameObject geri;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ayarlar.SetActive(false);
		oyna.SetActive(false);
		geri.SetActive(false);
		mEnu.SetActive(true);
		PlayerPrefs.SetInt("zorlUK",0); //0 normal, 1 zorlayıcı
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Ayarlar()
	{
		ayarlar.SetActive(true);
		oyna.SetActive(false);
		geri.SetActive(true);
		mEnu.SetActive(false);
	}

	public void Geri()
	{
		ayarlar.SetActive(false);
		oyna.SetActive(false);
		geri.SetActive(false);
		mEnu.SetActive(true);
	}
	
	public void Oyna()
	{
		ayarlar.SetActive(false);
		oyna.SetActive(true);
		geri.SetActive(true);
		mEnu.SetActive(false);
	}
	
	public void Normal()
	{
		PlayerPrefs.SetInt("zorlUK",0);
		Debug.Log("normal mod");
		Debug.Log(PlayerPrefs.GetInt("zorlUK"));
		SceneManager.LoadScene(0);
	}
	
	public void Crayz()
	{
		PlayerPrefs.SetInt("zorlUK",1);
		Debug.Log(PlayerPrefs.GetInt("zorlUK"));
		Debug.Log("zorlayıcı mod");
		SceneManager.LoadScene(0);
	}

}
