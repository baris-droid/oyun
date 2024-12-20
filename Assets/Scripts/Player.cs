using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float speed = 12;
	public static int difficulty; // Zorluk seviyesi (0: Normal, 1: Zor)

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
		difficulty = PlayerPrefs.GetInt("zorlUK");// Zorluk seviyesini al
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift) && difficulty == 0)
        {
            speed = 25;
        }
        else
        {
			if(difficulty == 1)
			{
				speed = 30;
			}
			else{
				speed = 12;
			}
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        _rb.linearVelocity = direction.normalized * speed;
        //transform.position += direction * speed * Time.deltaTime;
    }
}
