using UnityEngine;

public class Billdoard : MonoBehaviour
{
    public Transform cam;

    //LateUpdate вызывается после вызова всех функций обновления
    void LateUpdate()
    {
        //Поворачивает transform так, чтобы прямой вектор указывал на текущее положение
        transform.LookAt(transform.position + cam.forward);
    }
}
