using UnityEngine;
using System.Collections;

public class WaterManger : MonoBehaviour
{
    public int waterLvl;
    public float minHeight = -1.5f;
    public float maxHeight = 6.83f;

    public int amountOfWaterBeforeLose = 1000;

    float difMinMax;

	// Use this for initialization
	void Start ()
    {
        difMinMax = Mathf.Abs(minHeight - maxHeight);


    }
	
	// Update is called once per frame
	void Update ()
    {
        float posY = waterLvl/100;

        Vector3 finalPos = gameObject.transform.position;

        finalPos.y = posY;

        gameObject.transform.position = finalPos;
	
	}
}
