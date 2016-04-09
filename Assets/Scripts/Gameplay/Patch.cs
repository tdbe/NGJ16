using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Patch : MonoBehaviour
{
    public Transform mainCamera;
    public float range = 10f;
    public float timeToFix = 1f;
    public string tagToFix = "isFixable";
    public string tagToRestart = "restartLvl";
    float time;
    Renderer rend;
    Color colorStart;


    void FixedUpdate()
    {
        Vector3 fwd = mainCamera.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray = new Ray(mainCamera.position, fwd);

        Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward) * range, Color.red);

        if(Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.tag == tagToFix || hit.collider.tag == tagToRestart)
            {
            rend = hit.collider.gameObject.GetComponent<Renderer>();
            colorStart = rend.material.color;
            rend.material.color = Color.blue;
                if (Input.GetMouseButton(0))
                {
                    
                    time -= Time.deltaTime;
                    if (time < 0)
                    {
                        //FixStuff();
                        if(hit.collider.tag == tagToFix)
                            Destroy(hit.collider.gameObject);

                        if(hit.collider.tag == tagToRestart)
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                    }
                }

            } else
            {
                time = timeToFix;
                rend.material.color = colorStart;
            }
            
        }
    }

    public void FixStuff()
    {
        //Destroy()   
    }
}
