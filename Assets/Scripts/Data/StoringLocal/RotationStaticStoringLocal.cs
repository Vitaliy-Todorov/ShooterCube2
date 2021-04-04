using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RotationStatic", menuName = "StoringLocalData/RotationStatic", order = 2)]
public class RotationStaticStoringLocal : StoringLocalData
{
    [SerializeField]
    List<Vector3> listNormal = new List<Vector3>();

    public override List<Vector3> ListNormal { get => listNormal; set => listNormal = value; }
}
