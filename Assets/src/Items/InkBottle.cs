using UnityEngine;
using System.Collections;

public class InkBottle : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public InkBottle(string name) : base(name) { }
}
