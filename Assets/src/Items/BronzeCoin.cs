using UnityEngine;
using System.Collections;

public class BronzeCoin : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public BronzeCoin(string name) : base(name) { }
}
