using UnityEngine;
using System.Collections;

public class Battery : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public Battery(string name) : base(name) { }
}
