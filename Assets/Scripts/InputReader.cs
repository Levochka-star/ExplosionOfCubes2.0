using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode _clikedOnButton = KeyCode.Mouse2;

    public event Action<Vector3> Clicked;

    private void Update()
    {
        if (Input.GetKeyDown(_clikedOnButton))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}