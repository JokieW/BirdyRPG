using UnityEngine;
using System.Collections;

public class Match : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public Match(string name) : base(name) { }
}
