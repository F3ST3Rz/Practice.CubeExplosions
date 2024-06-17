using UnityEngine;

[RequireComponent(typeof(Sharer))]
public class Cube : MonoBehaviour
{
    private Sharer _sharer;

    private void Awake()
    {
        _sharer = GetComponent<Sharer>();
    }

    public void Destroy()
    {
        _sharer.ChanceSpawn();
        GameObject.Destroy(gameObject);
    }

    public void ChangeScale(float value)
    {
        _sharer.ChangeSplit(value);
        transform.localScale /= value;
    }
}

