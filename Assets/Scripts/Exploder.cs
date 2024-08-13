using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private float _minExplosionForce = 50f;
    [SerializeField] private float _minExplosionRadius = 10f;
    [SerializeField] private float _maxExplosionForce = 500f;
    [SerializeField] private float _maxExplosionRadius = 100f;

    public void Explode(float totalScale)
    {
        float explosionForce = Mathf.Lerp(_maxExplosionForce, _minExplosionForce, totalScale);
        float explosionRadius = Mathf.Lerp(_maxExplosionRadius, _minExplosionRadius, totalScale);

        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(explosionForce, transform.position, explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _minExplosionRadius);

        List<Rigidbody> barres = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                barres.Add(hit.attachedRigidbody);

        return barres;
    }
}
