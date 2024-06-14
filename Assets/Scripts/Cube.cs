using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Exploder))]
public class Cube : MonoBehaviour
{
    private float _divider = 2f;
    private int _minRangeNewObjects = 2;
    private int _maxRangeNewObjects = 6;
    private float _minRangeChanceSplit = 0f;
    private float _maxRangeChanceSplit = 1f;
    private float _chanceSplit = 1f;
    private Exploder _exploder;

    private void Start()
    {
        _exploder = GetComponent<Exploder>();

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }

    public void Destroy()
    {
        Share();
        GameObject.Destroy(gameObject); 
    }

    public void Change(float value)
    {
        transform.localScale /= value;
        _chanceSplit /= value;
    }

    private void Spawn()
    {
        var newCube = Instantiate(gameObject);
        newCube.SetActive(true);

        if (newCube.TryGetComponent(out Cube newCubeComponent))
        {
            newCubeComponent.enabled = true;
            newCubeComponent.Change(_divider);
        }

        if(newCube.TryGetComponent(out Rigidbody rigidbody))
            _exploder.AddExplodableObject(rigidbody);
    }

    private void Share()
    {
        if (Random.Range(_minRangeChanceSplit, _maxRangeChanceSplit) <= _chanceSplit)
            for (int i = 0; i < Random.Range(_minRangeNewObjects, _maxRangeNewObjects); i++)
                Spawn();
    }
}
