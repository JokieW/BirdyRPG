using UnityEngine;
using System.Collections;

public class SixpackRings : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public SixpackRings(string name) : base(name) { }
}
