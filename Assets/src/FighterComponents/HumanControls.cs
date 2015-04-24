using UnityEngine;
using System.Collections;

public class HumanControls : Controls 
{
    public KeyCode MoveUpKey;
    public KeyCode MoveDownKey;

    void Update()
    {
        if (Input.GetKeyDown(MoveUpKey))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(MoveDownKey))
        {
            MoveDown();
        }
    }
}
