using UnityEngine;
using System.Collections;

public class CrackedSmartphone : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public CrackedSmartphone(string name) : base(name) { }
}
