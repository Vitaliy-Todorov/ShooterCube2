using UnityEngine;

public class CallFinishMenu : MonoBehaviour
{
    [SerializeField]
    GameObject FinishMenu;
    [SerializeField]
    GameObject GameMenu;

    private void OnCollisionExit(Collision collision)
    {
        Destroy(GameMenu);

        FinishMenu.gameObject.SetActive(true);
        Destroy(collision.collider);
    }
}
