using UnityEngine;
using System.Collections;

public class Patch : MonoBehaviour
{
    public Transform mainCamera;
    public float range = 10f;
    public float timeToFix = 1f;
    public string tagToFix = "isFixable";
    float time;
    Renderer rend;

	void FixedUpdate()
    {
        Vector3 fwd = mainCamera.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray = new Ray(mainCamera.position, fwd);

        Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward) * range, Color.red);

        if(Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.tag == tagToFix)
            {
            rend = hit.collider.gameObject.GetComponent<Renderer>();
            rend.material.color = Color.blue;
                if (Input.GetMouseButton(0))
                {
                    
                    time -= Time.deltaTime;
                    if (time < 0)
                    {
                        //FixStuff();
                        Destroy(hit.collider.gameObject);
                    }
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
