using UnityEngine;
using System.Collections;

public class NewspaperPage : Ditto 
{
	protected override void OnEffect(GameObject target)
	{
		
	}
	
	public override bool StillAlive()
	{
	    return false;
	}

    public NewspaperPage(string name) : base(name) { }
}
