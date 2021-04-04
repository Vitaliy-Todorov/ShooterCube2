using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    GameObject finish;

    [SerializeField]
    GameObject �allGameMenu;

    private void OnCollisionEnter(Collision collision)
    {
        �allGameMenu.GetComponent<CallGameMenu>().enabled = false;
        Destroy(collision.collider);
        finish.gameObject.SetActive(true);
    }
}
