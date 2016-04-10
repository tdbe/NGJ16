using UnityEngine;
using System.Collections;

public class CausticScroll : MonoBehaviour {

    public float rotateSpeed = 0.5F;
    public float translateSpeed = 0.5F;
    //public float translateSpeedX = 0.5F;
    //public float translateSpeedZ = 0.5F;
    public float translateScale = 0.1F;
    public float translateZOffset = 1.5f;
    //public AnimationCurve moveX;
    //public AnimationCurve moveZ;
    public int direction = 1;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime);
        //float angle = Mathf.Abs(transform.localRotation.eulerAngles.z * translateScale);
        /*
        transform.parent.Translate((Vector3.left * translateSpeed * moveX.Evaluate(angle)  
                                    + 
                                    Vector3.forward * translateSpeed * moveX.Evaluate(angle+ translateZOffset)
                                    ) * Time.deltaTime);*/

        
        Vector3 dir = (Vector3.left * translateSpeed
                                    +
                                    Vector3.forward * translateSpeed
                                    ) * Time.deltaTime * direction;

        transform.parent.Translate((Vector3.left * translateSpeed
                                    +
                                    Vector3.forward * translateSpeed
                                    ) * Time.deltaTime * direction);
        //Debug.Log(dir);
    }
}
