using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHole : MonoBehaviour
{
    Dictionary<GameObject, int> sourceLayers = new Dictionary<GameObject, int>();
/*
    private void OnCollisionEnter(Collision collision)
    {
        GameObject gmObj;
        Transform transformCollider = collision.transform.Find("Collider");

        Debug.Log("OnCollisionEnter");
        foreach (Transform transform in transformCollider)
        {
            gmObj = transform.gameObject;
            sourceLayers.Add(gmObj, gmObj.layer);
            gmObj.layer = 12;
            Debug.Log("Enter: " + gmObj);
        }
    }*/
/*
    private void OnCollisionExit(Collision collision)
    {
        GameObject gmObj;
        Transform transformCollider = collision.transform.Find("Collider");

        Debug.Log("OnCollisionExit");
        foreach (Transform transform in transformCollider)
        {
            gmObj = transform.gameObject;
            Debug.Log("Exit: " + gmObj);
            gmObj.layer = sourceLayers[gmObj];
            sourceLayers.Remove(gmObj);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        GameObject gmObj = other.gameObject;
        sourceLayers.Add(gmObj, gmObj.layer);
        gmObj.layer = 12;
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gmObj = other.gameObject;
        gmObj.layer = sourceLayers[gmObj];
        sourceLayers.Remove(gmObj);
    }
}
