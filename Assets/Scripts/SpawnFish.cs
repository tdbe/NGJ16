using UnityEngine;
using System.Collections;

public class SpawnFish : MonoBehaviour {


    public GameObject fish;
    public Transform mothersChild;
    public float spawnTime = 5; // spawn time in seconds.
    public int maxHeight = 45; // height in rotation
    private float timePassed = 0; // time that went by

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if (timePassed >= spawnTime) {
            SpawnAndRotate();
            timePassed = 0;
        }
        
	}



    public void SpawnAndRotate() {
        int yrotation = Random.Range(0,361);
        int zrotation = Random.Range(0, maxHeight);
        transform.Rotate(new Vector3(0,yrotation,zrotation));
        
        Instantiate(fish, mothersChild.position, transform.rotation);
        
        transform.rotation = Quaternion.identity;   
    }



}
