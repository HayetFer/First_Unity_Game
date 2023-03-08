using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFingersPlatform : MonoBehaviour
{
    private GameObject emptyObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "playa")
        {
            emptyObject = new GameObject("Empty");
            emptyObject.transform.SetParent(transform, true);
            collision.gameObject.transform.SetParent(emptyObject.transform, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "playa")
        {
            collision.gameObject.transform.SetParent(null);
            Destroy(emptyObject);
        }
    }
}

