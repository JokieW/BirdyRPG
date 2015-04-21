using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Altimeter))]
public class FighterRenderer : MonoBehaviour 
{
    private CompCache<MeshRenderer> _renderer;
    private CompCache<MeshFilter> _filter;
    private CompCache<Altimeter> _altimeter;

    void Awake()
    {
        _renderer = new CompCache<MeshRenderer>(gameObject);
        _filter = new CompCache<MeshFilter>(gameObject);
        _altimeter = new CompCache<Altimeter>(gameObject);
    }
}
