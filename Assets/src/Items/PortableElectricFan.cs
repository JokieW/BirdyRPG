using UnityEngine;
using System.Collections;

public class PortableElectricFan : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public PortableElectricFan(string name) : base(name) { }
}
