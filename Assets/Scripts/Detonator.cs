using UnityEngine;

public class Detonator : MonoBehaviour
{
    private float _radius;
    private int _maxRadius = 500;
    private float _power;
    private int _powerCoefficient = 10;

    public void Work(Cube cube)
    {
        if (cube.gameObject.TryGetComponent(out RadiusReader radiusReader))
        {
            _radius = _maxRadius / radiusReader.Radius;
            _power = _radius * _powerCoefficient;
        }

        Vector3 explosionPos = cube.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, _radius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(_power, explosionPos, _radius, 3.0F);
        }
    }
}