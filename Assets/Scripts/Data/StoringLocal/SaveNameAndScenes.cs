using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nwe Save Data", menuName = "SaveNameAndScenes", order = 2)]
public class SaveNameAndScenes : ScriptableObject
{
    [SerializeField]
    List<string> saves;
    [SerializeField]
    List<string> scenes;

    public List<string> Saves { get => saves; set => saves = value; }

    public void AddSave(string save, string scene)
    {
        Saves.Add(save);
        scenes.Add(scene);
    }

    public string GetScenes(string save)
    {
        return scenes[Saves.IndexOf(save)];
    }

    public void ChangeScene(string save, string scene)
    {
        scenes[Saves.IndexOf(save)] = scene;
    }

    public bool ContainsSave(string save)
    {
        return saves.Contains(save);
    }
}
