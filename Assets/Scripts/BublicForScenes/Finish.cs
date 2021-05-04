using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    GameObject finish;

    [SerializeField]
    GameObject �allGameMenu;

    private void OnTriggerExit(Collider other)
    {
        �allGameMenu.GetComponent<CallGameMenu>().enabled = false;
        finish.gameObject.SetActive(true);
    }
}
