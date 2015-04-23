using UnityEngine;
using System.Collections;

public class BreadCrumb : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public BreadCrumb(string name) : base(name) { }
}
