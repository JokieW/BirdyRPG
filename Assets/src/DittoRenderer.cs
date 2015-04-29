using UnityEngine;
using System.Collections;

public class DittoRenderer : MonoBehaviour 
{
    private Ditto _ditto;
    public Ditto Ditto
    {
        get
        {
            return _ditto;
        }
        set
        {
            _ditto = value;

        }
    }

}
