using UnityEngine;
using System.Collections;

public class SilverCoin : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public SilverCoin(string name) : base(name) { }
}
