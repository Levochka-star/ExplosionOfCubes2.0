using UnityEngine;

public class RadiusReader : MonoBehaviour
{
    public float Radius {get ; private set;}

    private void Start()
    {
        Radius = transform.localScale.x;
    }
}