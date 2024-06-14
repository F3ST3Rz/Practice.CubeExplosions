using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Exploder : MonoBehaviour
{
    [SerializeField] float _explosionForce = 1000f;
    [SerializeField] float _explosionRadius = 50f;

    private List<Rigidbody> _explodableObjects;

    private void Start()
    {
        _explodableObjects = new List<Rigidbody>();
    }

    private void OnDestroy()
    {
        Explode();
    }

    public void AddExplodableObject(Rigidbody rigidbody)
    {
        _explodableObjects.Add(rigidbody);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in _explodableObjects)
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
