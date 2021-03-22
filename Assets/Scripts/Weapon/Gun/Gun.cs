using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float damege = 20.0f;

    [SerializeField]
    GameObject bullet;

    public void Shot()
    {
        Vector3 ganPosition = transform.position;
        Quaternion ganRotation = transform.localRotation;
        GameObject newBullet = Instantiate(bullet, ganPosition, ganRotation);
        newBullet.transform.parent = transform.parent;

        newBullet.GetComponent<InflictDamage>().Damege = damege;
        newBullet.GetComponent<BulletMotion>().Position = transform.forward;
    }
}
