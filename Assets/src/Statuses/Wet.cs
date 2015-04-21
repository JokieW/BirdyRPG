using UnityEngine;
using System.Collections;

public class Wet : Ditto 
{
    protected override void OnEffect(GameObject target)
    {
       
    }

    public override bool StillAlive()
    {
        if(TimeSinceStart() >= 5.0f)
        {
        	return false;
        }
        	return true;
    }

    public Wet(string name) : base(name){}
}
