using UnityEngine;
using System.Collections;

public class MoveFish : MonoBehaviour {

    public float moveSpeed;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}


}
