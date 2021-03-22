using UnityEngine;

public class BulletMotion : Motion
{
    [SerializeField]
    float speed = 15.0F;
    //направление оружия
    private Vector3 ganPosition;
    public Vector3 Position { set { ganPosition = value; } }

    private void Start()
    {
        Destroy(gameObject, 1.4F);
    }

    private void FixedUpdate()
    {
        Move(ganPosition, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
