using UnityEngine;
using System.Collections;

public class EmptySodacan : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public EmptySodacan(string name) : base(name) { }
}
