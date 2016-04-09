using UnityEngine;
using System.Collections;

public class MoveFish : MonoBehaviour {

    public float moveSpeed;

	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);


	}

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        

    }


}
