using UnityEngine;
using System.Collections;

public class WaterBalloon : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public WaterBalloon(string name) : base(name) { }
}
