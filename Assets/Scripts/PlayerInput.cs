using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _keyDestroy = KeyCode.Mouse0;

    private Camera _camera;
    private float _minRangeChanceSplit = 0f;
    private float _maxRangeChanceSplit = 1f;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(_keyDestroy))
            DestroyObject();
    }

    private void DestroyObject()
    {
        Vector3 mousePosition = Input.mousePosition;
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit))
            if (hit.transform.TryGetComponent(out Cube cube))
                cube.Destroy(TrySeparate(cube));
    }

    private bool TrySeparate(Cube cube)
    {
        bool isSeparate = Random.Range(_minRangeChanceSplit, _maxRangeChanceSplit) <= cube.ChanceSplit;

        return isSeparate;
    }
}
