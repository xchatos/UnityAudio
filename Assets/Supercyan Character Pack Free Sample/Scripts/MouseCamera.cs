using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public Transform target;

    float xAxis;
    float yAxis;

    public float distance = 10.0f;
    public float height;
    public float speed = 5.0f;

    private void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {

        xAxis += Input.GetAxis("Mouse X") * speed;
        yAxis  -= Input.GetAxis("Mouse Y") * speed;

        Quaternion rotation = Quaternion.Euler(yAxis, xAxis, 0.0f);

        transform.rotation = rotation;

        transform.position = target.position + rotation * new Vector3(0.0f, height, -distance);
    }


}
