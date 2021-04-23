using UnityEngine;

/// <summary>
/// Родительсткий класс компонента, данные которого мы будем сохранять
/// </summary>
public abstract class SaveLoadComponent : MonoBehaviour
{
    /// <summary>
    /// Сохраняем данные отдельного компонента
    /// </summary>
    public abstract void Save();

    public abstract void Load();
}
