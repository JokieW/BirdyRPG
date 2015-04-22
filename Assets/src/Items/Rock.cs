using UnityEngine;
using System.Collections;

public class Rock : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
		if(TimeSinceStart() >= 5.0f)
		{
			return false;
		}
		return true;
	}
	
	public Rock(string name) : base(name){}
}
