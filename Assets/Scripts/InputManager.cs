using UnityEngine;
using System;
public class InputManager : MonoBehaviour
{
    public static event Action OnTap;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTap?.Invoke();
        }
    }
}
