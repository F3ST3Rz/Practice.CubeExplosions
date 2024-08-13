using Unity.VisualScripting;
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

    private void Spawn()
    {
        var newCube = Instantiate(_cube);
        newCube.ChangeScale(_divider);
        newCube.ChangeChanceSplit(_cube.ChanceSplit, _divider);
        newCube.gameObject.SetActive(true);
        newCube.enabled = true;
    }

    public void Separate()
    {
        int countNewObjects = Random.Range(_minRangeNewObjects, _maxRangeNewObjects);

        for (int i = 0; i < countNewObjects; i++)
            Spawn();
    }
}

