using UnityEngine;
using System.Collections;

public class Paralysed : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		//Paralyses the target, keeping it attacking at all
	}
	
	public override bool StillAlive()
	{
		if(TimeSinceStart() >= 3.0f)
		{
			return false;
		}
		return true;
	}
	
	public Paralysed(string name) : base(name){}
}
