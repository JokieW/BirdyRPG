using UnityEngine;
using System.Collections;

public class Attached : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		//Keeps the target from going to High flight
	}
	
	public override bool StillAlive()
	{
		if(TimeSinceStart() >= 5.0f)
		{
			return false;
		}
		return true;
	}
	
	public Attached(string name) : base(name){}
}
