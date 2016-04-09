using UnityEngine;
using System.Collections;

public class CausticScroll : MonoBehaviour {

    public float rotateSpeed = 0.5F;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed);
    }
}
