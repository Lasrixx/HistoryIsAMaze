using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorTilt : MonoBehaviour
{
    Rigidbody rb;
    private float minX = -1.0f, maxX = 1.0f;
    private float minZ = -1.0f, maxZ = 1.0f;
    public float maxTilt;
    public float minTilt;
    public float speed;

    public Slider xSlider;
    public Slider zSlider;
    private float rotXPercent;
    private float rotZPercent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Tilt();
        FillAxes();
    }

    void Tilt()
    {
        if ((Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("LeftJoyStickHort") > 0.2) && transform.rotation.x <= maxTilt)
        {
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
        if ((Input.GetAxis("Horizontal") < -0.1 || Input.GetAxis("LeftJoyStickHort") < -0.2) && transform.rotation.x >= minTilt)
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }
        if ((Input.GetAxis("Vertical") > 0.1 || Input.GetAxisRaw("RightJoyStickVert") < -0.2) && transform.rotation.z <= maxTilt)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        if ((Input.GetAxis("Vertical") < -0.1 || Input.GetAxis("RightJoyStickVert") > 0.2) && transform.rotation.z >= minTilt)
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
        }
    }
    void FillAxes()
    {
        //Fill x axis
        float xBound = 11.5f;
        float zBound = 11.5f;
        Quaternion rot = transform.rotation;            
        rotXPercent = rot.x * 115 / xBound * 100;
        xSlider.value = rotXPercent;
        rotZPercent = rot.z * 115 / zBound * 100;
        zSlider.value = rotZPercent;
    }
}
