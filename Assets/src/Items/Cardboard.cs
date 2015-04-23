using UnityEngine;
using System.Collections;

public class Cardboard : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public Cardboard(string name) : base(name) { }
}
