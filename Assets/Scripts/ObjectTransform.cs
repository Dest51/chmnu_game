using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransform : MonoBehaviour
{

    public float scaleSpeed = 0.1f; 
    public float rotationSpeed = 30f;  
    public float maxScale = 2.0f;  
    public float minScale = 0.5f;
    public float maxRotationAngle = 180f; 

    private bool isScalingUp = true;
    private bool rotateClockwise = true;

    void Update()
    {
        if (isScalingUp)
        {
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0) * Time.deltaTime;

            if (transform.localScale.x >= maxScale)
            {
                transform.localScale = new Vector3(maxScale, maxScale, 1);
                isScalingUp = false;  
            }
        }
        else
        {
            transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, 0) * Time.deltaTime;

            if (transform.localScale.x <= minScale)
            {
                transform.localScale = new Vector3(minScale, minScale, 1);
                isScalingUp = true;  
            }
        }

        float rotationDelta = rotationSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.rotation.eulerAngles.z) >= maxRotationAngle)
        {
            rotateClockwise = !rotateClockwise;  
        }

        if (rotateClockwise)
        {
            transform.Rotate(Vector3.forward * rotationDelta);
        }
        else
        {
            transform.Rotate(Vector3.forward * -rotationDelta);
        }
    }
}
