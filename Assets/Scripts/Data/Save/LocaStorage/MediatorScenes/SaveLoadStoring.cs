using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveLoadStoring
{
    public abstract void Save(Dictionary<string, object> dictionary, string fileName);

    public abstract Dictionary<string, object> Load(string fileName);
}
