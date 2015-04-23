using UnityEngine;
using System.Collections;

public class RustySpring : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public RustySpring(string name) : base(name) { }
}
