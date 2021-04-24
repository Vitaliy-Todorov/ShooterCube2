using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLabyrinth : MonoBehaviour
{
    [SerializeField]
    GameObject rotatable;
    [SerializeField]
    GameObject noRotatable;

    [SerializeField]
    Vector3 eulers;

    bool completed;

    private void OnTriggerEnter(Collider other)
    {
        rotatable.transform.Rotate(eulers);
        noRotatable.transform.Rotate(-eulers);

        eulers = -eulers;
    }
}
