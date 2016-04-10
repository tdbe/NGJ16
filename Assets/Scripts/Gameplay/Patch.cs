﻿using UnityEngine;
using System.Collections;

public class Patch : MonoBehaviour
{
    public Transform mainCamera;
    public float range = 10f;
    public float timeToFix = 1f;
    public string tagToFix = "isFixable";
    float time;
    public LineRenderer lineRenderer;



    private static Patch s_Instance;


    public static Patch Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType<Patch>();
                DontDestroyOnLoad(s_Instance.gameObject);
            }

            return s_Instance;
        }
    }


    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != s_Instance)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        mainCamera = Camera.main.transform;
        lineRenderer = GetComponent<LineRenderer>();
    }

	public void UpdateLineRenderer(Vector3 destination)
    {
        //Debug.Log("OnDown in general");
        lineRenderer.SetPosition(0, gameObject.transform.position);
        lineRenderer.SetPosition(1, destination);
    }

    //Line renderer must be updated every now and then, not every frame. Need to look at the Over event in VRInteractiveItem.cs (which goes on each target)
    public void UpdateLineRendererOnTarget(Vector3 destination)
    {
        
        UpdateLineRenderer(destination);
    }

    void Update()
    {
        //Camera.main.transform.Rotate(Vector3.up,Time.deltaTime);
    }

    /*
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
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.tag == tagToFix)
                {
                    time -= Time.deltaTime;
                    if (time < 0)
                    {
                        //Destroy(hit.collider.gameObject);

                        hit.collider.gameObject.GetComponent<VRStandardAssets.Utils.VRInteractiveItem>().Down();
                    }
                }
            }
        }
        else
        {
            time = timeToFix;
        }
    }*/
}
