using UnityEngine;
using System.Collections;

public class WaterBottle : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public WaterBottle(string name) : base(name) { }
}
