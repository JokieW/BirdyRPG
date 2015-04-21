using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(TargetPicker))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(Statuses))]
[RequireComponent(typeof(Stats))]
[RequireComponent(typeof(Altimeter))]
[Serializable]
public class Fighter : MonoBehaviour 
{
    private bool _isAPlayer = false;
    public bool IsAPlayer
    {
        get
        {
            return _isAPlayer;
        }
    }
}
