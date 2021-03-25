using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanEnemy : Gun
{
    [SerializeField]
    float frequencyæ = 2.4f;

    void Start()
    {
        ShotEnemy();
    }

    void ShotEnemy()
    {
        Shot();
        Invoke("ShotEnemy", frequencyæ);
    }
}
