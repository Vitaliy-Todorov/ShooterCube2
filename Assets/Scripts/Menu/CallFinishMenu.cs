using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFinishMenu : MonoBehaviour
{
    [SerializeField]
    GameObject FinishMenu;
    [SerializeField]
    GameObject GameMenu;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(GameMenu);

        FinishMenu.gameObject.SetActive(true);
        Destroy(collision.collider);
    }
}
