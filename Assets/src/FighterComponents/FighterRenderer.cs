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

    void Update()
    {
        MoveTowardCurrentAltimeter();
    }

    void MoveTowardCurrentAltimeter()
    {
        transform.Translate(((_altimeter.get.CurrentLevel - transform.position) / 3) * Time.deltaTime * 15.0f);
    }
}
