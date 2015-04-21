using UnityEngine;
using System.Collections;

public class Sick : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		target.GetComponent<Statuses>().GetEffect<EnergyRegen>().RegenRate = 0.5f;
	}
	
	public override bool StillAlive()
	{
		if(TimeSinceStart() >= 10.0f)
		{
			return false;
		}
		return true;
	}
	
	public Sick(string name) : base(name){}
}
