using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Exploder : MonoBehaviour
{
    [SerializeField] float _explosionForce = 1000f;
    [SerializeField] float _explosionRadius = 50f;

    public void Explode(List<Rigidbody> explodableObjects)
    {
        foreach (Rigidbody explodableObject in explodableObjects)
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
