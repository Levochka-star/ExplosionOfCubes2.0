using System;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputUser;

    public event Action<Cube> UserClicedOnCube;

    private void OnEnable()
    {
        _inputUser.Clicked += Work;
    }

    private void OnDisable()
    {
        _inputUser.Clicked -= Work;
    }
    private void Work(Vector3 vector3)
    {
        Ray ray = new Ray();

        ray = _camera.ScreenPointToRay(vector3);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
           if (hit.collider.gameObject.TryGetComponent<Cube>(out Cube cube))
            {
                UserClicedOnCube?.Invoke(cube);
            }
        }
    }
}
