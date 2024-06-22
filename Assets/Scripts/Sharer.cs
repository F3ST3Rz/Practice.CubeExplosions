using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Sharer : MonoBehaviour
{
    private float _divider = 2f;
    private Cube _cube;
    private int _minRangeNewObjects = 2;
    private int _maxRangeNewObjects = 6;

    private void Start()
    {
        _cube = GetComponent<Cube>();
    }

    public void Separate()
    {
        int countNewObjects = Random.Range(_minRangeNewObjects, _maxRangeNewObjects);

        for (int i = 0; i < countNewObjects; i++)
            Spawn();
    }

    private void Spawn()
    {
        var newCube = Instantiate(_cube);
        newCube.gameObject.SetActive(true);
        newCube.enabled = true;
        newCube.ChangeObject(_divider);
    }
}

