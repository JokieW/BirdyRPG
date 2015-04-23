using UnityEngine;
using System.Collections;

public class ElectricWire : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public ElectricWire(string name) : base(name) { }
}
