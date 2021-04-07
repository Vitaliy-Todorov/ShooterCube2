using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListHealth", menuName = "StoringLocalData/RotationStatic", order = 2)]
public class ListHealthStoringLocal : StoringLocalData
{
    [SerializeField]
    List<float> listHealth = new List<float>();

    public override List<float> ListHealth { get => listHealth; set => listHealth = value; }
}
