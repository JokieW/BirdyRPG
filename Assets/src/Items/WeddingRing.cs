using UnityEngine;
using System.Collections;

public class WeddingRing : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public WeddingRing(string name) : base(name) { }
}
