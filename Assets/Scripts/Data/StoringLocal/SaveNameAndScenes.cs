using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nwe Save Data", menuName = "SaveNameAndScenes", order = 2)]
public class SaveNameAndScenes : ScriptableObject
{
    [SerializeField]
    Dictionary<string, string> saveNameAndScenes = new Dictionary<string, string>();

    [SerializeField]
    public float health = 10;

    public Dictionary<string, string> Dictionary { get => saveNameAndScenes; set => saveNameAndScenes = value; }
}
