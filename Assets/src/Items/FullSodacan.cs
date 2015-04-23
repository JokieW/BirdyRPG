using UnityEngine;
using System.Collections;

public class FullSodacan : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public FullSodacan(string name) : base(name) { }
}
