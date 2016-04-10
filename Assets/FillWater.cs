using UnityEngine;
using System.Collections;

public class FillWater : MonoBehaviour
{
    public GameObject water;
    float startTimer = 1;
    float timer;

	// Use this for initialization
	void Start ()
    {
        timer = startTimer;
        water = GameObject.FindGameObjectWithTag("risingWater");
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            water.GetComponent<WaterManger>().waterLvl += 1;
            timer = startTimer;
        }
	
	}
}
