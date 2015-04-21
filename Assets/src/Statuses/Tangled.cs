using UnityEngine;
using System.Collections;

public class Tangled : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		Statuses Check = target.GetComponent<Statuses>();
		if(Check.HasEffect<Energized>() && Check.HasEffect<Wet>())
		{
			target.GetComponent<Stats>().HP -= 2;
		}
		else if(Check.HasEffect<Energized>())
		{
			target.GetComponent<Stats>().HP -= 3;
		}
	}
	
	public override bool StillAlive()
	{
		if(TimeSinceStart() >= 10.0f)
		{
			return false;
		}
		return true;
	}
	
	public Tangled(string name) : base(name){}
}
