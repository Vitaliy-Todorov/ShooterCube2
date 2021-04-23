using UnityEngine;
using System;

public class LocalStorage
{
    [SerializeField]
    Vector3 _vector3;

    [SerializeField]
    float _float;

    [SerializeField]
    bool _bool;

    [SerializeField]
    private HealthAndDeathLocaStorage _healthAndDeath;

    public LocalStorage() { }

    public LocalStorage(Vector3 vector3)
    {
        Vector3 = vector3;
    }

    public LocalStorage(float float_)
    {
        Float = float_;
    }

    public LocalStorage(bool bool_)
    {
        Bool = bool_;
    }

    public LocalStorage(HealthAndDeathLocaStorage healthAndDeath)
    {
        _healthAndDeath = healthAndDeath;
    }

    public Vector3 Vector3 { get => _vector3; set => _vector3 = value; }
    public float Float { get => _float; set => _float = value; }
    public bool Bool { get => _bool; set => _bool = value; }

    public HealthAndDeathLocaStorage HealthAndDeath { 
        get 
        {
            if (_healthAndDeath == null)
                _healthAndDeath = new HealthAndDeathLocaStorage();

            return _healthAndDeath;
        }

        set
        {
            if (_healthAndDeath == null)
                _healthAndDeath = new HealthAndDeathLocaStorage();

            _healthAndDeath = value;
        }
    }
}
