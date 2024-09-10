using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode _flyKey = KeyCode.Space;
    private int _keyShoot = 0;
    private KeyCode _pauseKey = KeyCode.Escape;

    public event Action FlyKeyPressing;
    public event Action ShootKeyPressing;
    public event Action PauseKeyPressing;

    private void Update()
    {
        if (Input.GetKeyDown(_flyKey))
        {
            FlyKeyPressing?.Invoke();
        }

        if (Input.GetMouseButtonDown(_keyShoot))
        {
            ShootKeyPressing?.Invoke();
        }

        if (Input.GetKeyDown(_pauseKey))
        {
            PauseKeyPressing?.Invoke();
        }
    }
}
