using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float damege = 20.0f;

    [SerializeField]
    float speed = 15.0F;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform parent;

    public void Shot()
    {
        Vector3 ganPosition = transform.position;
        Quaternion ganRotation = transform.localRotation;
        //—мещаем по€вление пули немного вперЄд, что бы она не двигала стрел€ющий куб
        ganPosition += transform.forward * 0.3f;
        GameObject newBullet = Instantiate(bullet, ganPosition, ganRotation);
        newBullet.transform.parent = parent;

        newBullet.GetComponent<InflictDamage>().Damege = damege;
        newBullet.GetComponent<BulletMotion>().Speed = speed;
        newBullet.GetComponent<BulletMotion>().Position = transform.forward;
    }
}
