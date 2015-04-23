using UnityEngine;
using System.Collections;

public class Candy : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public Candy(string name) : base(name) { }
}
