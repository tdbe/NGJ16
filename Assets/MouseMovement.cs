using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour
{

    public float speed;
    void Start()
    {
    }

    void Update()
    {
        float moveX = Input.GetAxis("Mouse X") * speed;
        float moveY = Input.GetAxis("Mouse Y") * -speed;
        transform.Rotate(moveY, moveX, 0);
    }
}