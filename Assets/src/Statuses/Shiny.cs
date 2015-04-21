using UnityEngine;
using System.Collections;

public class Shiny : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		//deals 1.5X dmg if target is the Jackdaw
	}
	
	public override bool StillAlive()
	{
		return true;
	}
	
	public Shiny (string name) : base(name){}
}
