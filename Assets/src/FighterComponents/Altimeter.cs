using UnityEngine;
using System;
using System.Collections;

public class Altimeter : MonoBehaviour 
{
    public Vector3 FloorLevel;
    public Vector3 CeilingLevel;

    [SerializeField]
    private Vector3 _currentLevel;
    public Vector3 CurrentLevel
    {
        get
        {
            return _currentLevel;
        }
    }

    [SerializeField]
    private Altitude _currentAltitude;
    public Altitude CurrentAltitude
    {
        get
        {
            return _currentAltitude;
        }
        set
        {
            _currentAltitude = value;
            Vector3 segments = (CeilingLevel - FloorLevel) / (AltCount - 1);
            _currentLevel = segments * (int)value;

        }
    }

    public void GoUp()
    {
        if ((int)_currentAltitude < AltCount - 1)
        {
            CurrentAltitude++;
        }
    }

    public void GoDown()
    {
        if ((int)_currentAltitude > 0)
        {
            CurrentAltitude--;
        }
    }


    public enum Altitude
    {
        Ground = 0,
        Middle = 1,
        High = 2
    }

    private int AltCount
    {
        get
        {
            return Enum.GetValues(typeof(Altitude)).Length;
        }
    }
}
