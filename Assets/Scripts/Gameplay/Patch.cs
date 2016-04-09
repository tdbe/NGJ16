using UnityEngine;
using System.Collections;

public class Patch : MonoBehaviour
{
    public Transform mainCamera;
    public float range = 10f;
    public float timeToFix = 3f;
    float time;

	void FixedUpdate()
    {
        Vector3 fwd = mainCamera.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray = new Ray(mainCamera.position, fwd);

        Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward) * range, Color.red);

        if(Physics.Raycast(ray, out hit, range))
        {
            if (Input.GetMouseButton(0))
            {
                if (hit.collider.tag == "isFixable")
                {
                    time -= Time.deltaTime;
                    if(time < 0)
                    {
                        FixStuff();
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
        
    }
}
