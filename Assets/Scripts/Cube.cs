using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sharer), typeof(Exploder))]
public class Cube : MonoBehaviour
{
    private Sharer _sharer;
    private Exploder _exploder;
    private int _minRangeNewObjects = 2;
    private int _maxRangeNewObjects = 6;
    private float _minRangeChanceSplit = 0f;
    private float _maxRangeChanceSplit = 1f;
    private float _chanceSplit = 1f;

    private void Start()
    {
        _sharer = GetComponent<Sharer>();
        _exploder = GetComponent<Exploder>();
    }

    public void Destroy()
    {
        TrySeparate();
        GameObject.Destroy(gameObject);
    }

    public void ChangeScale(float value)
    {
        transform.localScale /= value;
    }

    public void ChangeSplit(float value)
    {
        _chanceSplit /= value;
    }

    private void TrySeparate()
    {
        if (Random.Range(_minRangeChanceSplit, _maxRangeChanceSplit) <= _chanceSplit)
        {
            int countNewObjects = Random.Range(_minRangeNewObjects, _maxRangeNewObjects);
            List<Rigidbody> explodableObjects = new List<Rigidbody>();

            for (int i = 0; i < countNewObjects; i++)
                explodableObjects.Add(_sharer.Spawn());

            _exploder.Explode(explodableObjects);
        }
    }
}

