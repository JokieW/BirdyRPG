using UnityEngine;
using System.Collections;

public class SpoiledMilk : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public SpoiledMilk(string name) : base(name) { }
}
