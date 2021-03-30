using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Временное хранилище данных
/// </summary>
public class StoringLocalData : ScriptableObject
{
    private static List<StoringLocalData> listAllStoringLocal = new List<StoringLocalData>();

    public static List<StoringLocalData> ListAllStoringLocal { get => listAllStoringLocal; set => listAllStoringLocal = value; }

    public virtual Vector3 Position
    {
        set { throw new ArgumentException("У данного объекта не сущетствует свойства Position"); }
        get { throw new FieldAccessException("У данного объекта не сущетствует свойства Position"); }
    }

    public virtual Vector3 Normal
    {
        set { throw new ArgumentException("У данного объекта не сущетствует свойства Normal"); }
        get { throw new FieldAccessException("У данного объекта не сущетствует свойства Normal"); }
    }

    public virtual Vector3 NormalModel
    {
        set { throw new ArgumentException("У данного объекта не сущетствует свойства NormalModel"); }
        get { throw new FieldAccessException("У данного объекта не сущетствует свойства NormalModel"); }
    }

    public virtual float Health
    {
        set { throw new ArgumentException("У данного объекта не сущетствует свойства Health"); }
        get { throw new FieldAccessException("У данного объекта не сущетствует свойства Health"); }
    }

    public virtual bool CurrentDeath
    {
        set { throw new ArgumentException("У данного объекта не сущетствует свойства CurrentDeath"); }
        get { throw new FieldAccessException("У данного объекта не сущетствует свойства CurrentDeath"); }
    }

    public virtual bool SaveDeath
    {
        set { throw new ArgumentException("У данного объекта не сущетствует свойства SaveDeath"); }
        get { throw new FieldAccessException("У данного объекта не сущетствует свойства SaveDeath"); }
    }

    /// <summary>
    /// Сохраняем данные с унечтоженных объектов
    /// </summary>
    public virtual void SaveDestroy() { }

    /// <summary>
    /// Сохраняем данные со всех унечтоженных объектов
    /// </summary>
    public static void SaveDestroyAll() 
    {
        foreach (StoringLocalData storingLocal in listAllStoringLocal)
            storingLocal.SaveDestroy();
    }
}
