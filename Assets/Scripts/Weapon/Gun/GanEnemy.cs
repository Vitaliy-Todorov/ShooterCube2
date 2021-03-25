using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanEnemy : Gun
{
    [SerializeField]
    float frequency� = 2.4f;

    void Start()
    {
        ShotEnemy();
    }

    void ShotEnemy()
    {
        Shot();
        Invoke("ShotEnemy", frequency�);
    }
}
