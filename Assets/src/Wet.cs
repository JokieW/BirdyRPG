using UnityEngine;
using System.Collections;

public class Wet : Ditto 
{
    protected override void OnEffect(GameObject target)
    {
        
    }

    public override bool StillAlive()
    {
        return true;
    }

    public Wet(string name) : base(name){}
}
