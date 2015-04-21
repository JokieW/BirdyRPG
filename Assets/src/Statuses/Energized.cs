using UnityEngine;
using System.Collections;

public class Energized : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		Statuses Check = target.GetComponent<Statuses>();
		if(Check.HasEffect<Wet>())
		{
			target.GetComponent<Stats>().HP -= 3;
		}		
	}
	
	public override bool StillAlive()
	{
		if(TimeSinceStart() >= 3.0f)
		{
			return false;
		}
		return true;
	}
	
	public Energized (string name) : base(name){}
}
