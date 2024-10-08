using UnityEngine;

[RequireComponent(typeof(Sharer), typeof(Exploder))]
public class Cube : MonoBehaviour
{
    private float _chanceSplit = 1f;
    private Sharer _sharer;
    private Exploder _exploder;
    private float _totalScale;

    public float ChanceSplit => _chanceSplit;

    private void Start()
    {
        _exploder = GetComponent<Exploder>();
        _sharer = GetComponent<Sharer>();

        _totalScale = Mathf.Sqrt(Mathf.Pow(transform.localScale.x, 2) + Mathf.Pow(transform.localScale.y, 2) + Mathf.Pow(transform.localScale.z, 2));
    }

    public void Destroy(bool isSeparate)
    {
        if (isSeparate)
            _sharer.Separate();
        else
            _exploder.Explode(_totalScale);

        GameObject.Destroy(gameObject);
    }

    public void ChangeChanceSplit(float chanceSplit, float divider)
    {
        _chanceSplit = chanceSplit;
        _chanceSplit /= divider;
    }

    public void ChangeScale(float divider)
    {
        transform.localScale /= divider;
    }
}

