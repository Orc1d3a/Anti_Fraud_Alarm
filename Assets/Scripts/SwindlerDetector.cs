using System;
using UnityEngine;

public class SwindlerDetector : MonoBehaviour
{
    public event Action SwindlerEntered;
    public event Action SwindlerExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Swindler swindler))
        {
            SwindlerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Swindler swindler))
        {
            SwindlerExited?.Invoke();
        }
    }
}
