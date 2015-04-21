using UnityEngine;
using System.Collections;

public class Blind : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		//Blinds the target by rendering something appropriate that will cover the whole screen except for UI elements
	}
	
	public override bool StillAlive()
	{
		if(TimeSinceStart() >= 5.0f)
		{
			return false;
		}
		return true;
	}
	
	public Blind (string name) : base(name){}
}
