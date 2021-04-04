using UnityEngine;

public class BulletMotion : Motion
{
    [SerializeField]
    float speed = 15.0F;
    //направление оружия
    private Vector3 ganPosition;
    public Vector3 Position { set { ganPosition = value; } }

    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        Destroy(gameObject, 1.4F);
    }

    private void FixedUpdate()
    {
        Move(ganPosition, Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!transform.root.Equals(collision.transform.root))
            Destroy(gameObject);
    }
}
