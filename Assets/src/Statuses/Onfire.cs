using UnityEngine;
using System.Collections;

public class Onfire : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		target.GetComponent<Stats>().HP -= 3;
	}
	
	public override bool StillAlive()
	{
		if(TimeSinceStart() >= 3.0f)
		{
			return false;
		}
		return true;
	}
	
	public Onfire(string name) : base(name){}
}
