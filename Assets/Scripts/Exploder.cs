using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private RayReader _rayReader;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnEnable()
    {
        if (_rayReader == null)
        {
            _rayReader = FindObjectOfType<RayReader>();
            _explosionRadius = 5;
            _explosionForce = 100;
        }

        if (_rayReader != null)
        {
            _rayReader.ExplosionCubes += Explode;
        }
    }

    private void OnDisable()
    {
        _rayReader.ExplosionCubes -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> explosion = new();

        foreach (Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
            {
                explosion.Add(hit.attachedRigidbody);
            }
        }

        return explosion;
    }
}
