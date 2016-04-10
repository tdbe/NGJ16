using UnityEngine;
using System.Collections;

public class KillSelfAfterTime : MonoBehaviour {

    public float dieInSeconds = 5;
    private float startLifetime;

	// Use this for initialization
	void Start () {
        startLifetime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
	    if(Time.time- startLifetime > dieInSeconds)
        {
            Destroy(gameObject);
        }
	}
}
