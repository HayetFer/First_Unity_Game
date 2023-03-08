using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform targetObject;
    // Start is called before the first frame update
    public float smoothFactor=0.5f;
    public Vector3 cameraOffset;
    public bool lookAtTarget = false;
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position=Vector3.Slerp(transform.position, newPosition,smoothFactor);

        if(lookAtTarget){
            transform.LookAt(targetObject);
        }
    }
}
