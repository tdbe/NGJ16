using UnityEngine;
using System.Collections;

public class Patch : MonoBehaviour
{
    public Transform mainCamera;
    public float range = 10f;
    public float timeToFix = 1f;
    public string tagToFix = "isFixable";
    float time;
    public LineRenderer lineRenderer;

    void Start()
    {
        mainCamera = Camera.main.transform;
        lineRenderer = GetComponent<LineRenderer>();
    }

	void FixedUpdate()
    {
        Vector3 fwd = mainCamera.TransformDirection(Vector3.forward);
        
        RaycastHit hit;
        Ray ray = new Ray(mainCamera.position, fwd);

        Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward) * range, Color.red);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, range))
            {
                lineRenderer.SetPosition(0, gameObject.transform.position);
                lineRenderer.SetPosition(1, hit.transform.position);
                if (hit.collider.tag == tagToFix)
                {
                    time -= Time.deltaTime;
                    if (time < 0)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
        else
        {
            time = timeToFix;
        }
    }
}
