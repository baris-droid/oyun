using System.Collections;
using UnityEngine;

public class ImageColorChanger : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public float changeInterval = 1f;

    private void Start()
    {
        if (image == null)
        {
            image = GetComponent<UnityEngine.UI.Image>();
        }
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            image.color = new Color(Random.value, Random.value, Random.value);
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
