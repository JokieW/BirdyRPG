using UnityEngine;
using System.Collections;

public class InventoryWheel : MonoBehaviour 
{
    private Fighter _fighter;
    public Fighter CurrentFighter
    {
        get
        {
            return _fighter;
        }
        set
        {
            _fighter = value;
            ResetWheelTo(value);
            
        }
    }

    public Vector3 Center;


    void Update()
    {

    }

    private void ResetWheelTo(Fighter fight)
    {

    }

}
