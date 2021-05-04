using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    GameObject finish;

    [SerializeField]
    GameObject ñallGameMenu;

    private void OnTriggerExit(Collider other)
    {
        ñallGameMenu.GetComponent<CallGameMenu>().enabled = false;
        finish.gameObject.SetActive(true);
    }
}
