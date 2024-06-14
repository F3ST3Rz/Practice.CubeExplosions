using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _keyDestroy = KeyCode.Mouse0;

    private void Update()
    {
        if (Input.GetKeyUp(_keyDestroy))
            DestroyObject();
    }

    private void DestroyObject()
    {
        Vector3 mousePosition = Input.mousePosition;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit))
            if (hit.transform.TryGetComponent(out Cube cube))
                cube.Destroy();
    }
}
