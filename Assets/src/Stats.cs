using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour 
{
    [SerializeField]
    private float _hp;
    public float HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            if (_hp < 0)
            {
                _hp = 0;
            }
        }
    }

    [SerializeField]
    private float _energy;
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
            if (_energy < 0)
            {
                _energy = 0;
            }
        }
    }

    public bool RequestEnergy(float amount)
    {
        if (_energy < amount)
        {
            return false;
        }
        _energy -= amount;
        return true;
    }
}
