using UnityEngine;
using System.Collections;

public class Patch : MonoBehaviour
{
    public Transform mainCamera;
    public float range = 10f;
    public float timeToFix = 1f;
    public string tagToFix = "isFixable";
    float time;

	void FixedUpdate()
    {
        Vector3 fwd = mainCamera.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray = new Ray(mainCamera.position, fwd);

        Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward) * range, Color.red);

        if(Physics.Raycast(ray, out hit, range))
        {
        //Check for player input in if statement
                if (hit.collider.tag == tagToFix)
                {
                    time -= Time.deltaTime;
                    if(time < 0)
                    {
                        //FixStuff();
                        Destroy(hit.collider.gameObject);
                    }
                } else
                {
                    time = timeToFix; 
                }
            
        }
    }

    public void FixStuff()
    {
        //Destroy()   
    }
}
