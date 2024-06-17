using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Exploder))]
public class Sharer : MonoBehaviour
{
    private int _minRangeNewObjects = 2;
    private int _maxRangeNewObjects = 6;
    private float _minRangeChanceSplit = 0f;
    private float _maxRangeChanceSplit = 1f;
    private float _divider = 2f;
    private float _chanceSplit = 1f;
    private Exploder _exploder;

    private void Start()
    {
        _exploder = GetComponent<Exploder>();
    }

    public void ChangeSplit(float value)
    {
        _chanceSplit /= value;
    }

    public void ChanceSpawn()
    {
        if (Random.Range(_minRangeChanceSplit, _maxRangeChanceSplit) <= _chanceSplit)
        {
            int countNewObjects = Random.Range(_minRangeNewObjects, _maxRangeNewObjects);
            List<Rigidbody> explodableObjects = new List<Rigidbody>();

            for (int i = 0; i < countNewObjects; i++)
                explodableObjects.Add(Spawn());

            _exploder.Explode(explodableObjects);
        }
    }

    private Rigidbody Spawn()
    {
        if (TryGetComponent(out Cube cube))
        {
            var newCube = Instantiate(cube);
            newCube.gameObject.SetActive(true);
            newCube.enabled = true;
            newCube.ChangeScale(_divider);

            if (newCube.TryGetComponent(out Rigidbody rigidbody))
                return rigidbody;
        }

        return null;
    }
}

