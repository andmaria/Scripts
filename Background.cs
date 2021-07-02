using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    private float speed1, speed2, speed3;

	void Start () {
        InitializeSpeed();
    }
	
	void Update () {
        Rotate();
	}

    public void Rotate()
    {
        transform.Rotate(transform.right * speed1 * Time.deltaTime);
        transform.Rotate(transform.up * speed2 * Time.deltaTime);
        transform.Rotate(transform.forward * speed3 * Time.deltaTime);
    }

    public void InitializeSpeed()
    {
        speed1 = Random.Range(0.05f, 4f);
        speed2 = Random.Range(0.05f, 4f);
        speed3 = Random.Range(0.05f, 4f);
        if (Random.Range(0, 2) == 0)
            speed1 *= -1f;
        if (Random.Range(0, 2) == 0)
            speed2 *= -1f;
        if (Random.Range(0, 2) == 0)
            speed3 *= -1f;
    }
}
