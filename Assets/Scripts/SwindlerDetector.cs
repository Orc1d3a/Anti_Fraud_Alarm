using System;
using UnityEngine;

public class SwindlerDetector : MonoBehaviour
{
    public event Action SwindlerEnter;
    public event Action SwindlerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Swindler swindler))
        {
            SwindlerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Swindler swindler))
        {
            SwindlerExit?.Invoke();
        }
    }
}
