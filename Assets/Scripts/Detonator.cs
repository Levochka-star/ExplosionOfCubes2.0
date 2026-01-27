using UnityEngine;

public class Detonator : MonoBehaviour
{
    private float _radius;
    private int _maxRadius = 300;
    private float _power;
    private int _powerCoefficient = 5;

    public void Work()
    {
        if (gameObject.TryGetComponent(out RadiusReader radiusReader))
        {
            _radius = _maxRadius / radiusReader.Radius;
            _power = _radius * _powerCoefficient;
        }

        Vector3 explosionPos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, _radius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(_power, explosionPos, _radius, 3.0F);
        }
    }
}