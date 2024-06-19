using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Sharer : MonoBehaviour
{
    private float _divider = 2f;
    private Cube _cube;

    private void Start()
    {
        _cube = GetComponent<Cube>();
    }

    public Rigidbody Spawn()
    {
        var newCube = Instantiate(_cube);
        newCube.gameObject.SetActive(true);
        newCube.enabled = true;
        newCube.ChangeScale(_divider);
        newCube.ChangeSplit(_divider);

        if (newCube.TryGetComponent(out Rigidbody rigidbody))
            return rigidbody;

        return null;
    }
}

