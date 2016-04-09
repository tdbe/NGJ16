using UnityEngine;
using System.Collections;

public class CausticScroll : MonoBehaviour {

    public float rotateSpeed = 0.5F;
    public float translateSpeed = 0.5F;
    public AnimationCurve moveX;
    public AnimationCurve moveY;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime);
        float angle = Mathf.Abs(transform.localRotation.eulerAngles.y );
        Debug.Log(angle);
        transform.parent.Translate((Vector3.left * translateSpeed * moveX.Evaluate(angle)  
                                    + 
                                    Vector3.forward * translateSpeed * moveY.Evaluate(angle)
                                    ) * Time.deltaTime);
    }
}
