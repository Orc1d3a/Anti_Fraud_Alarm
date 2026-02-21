using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private SwindlerDetector _swindlerDetector;
    [SerializeField] private Alarm _alarm;

    private float _targetVolume = 0;

    private void OnEnable()
    {
        _swindlerDetector.SwindlerEntered += Play;
        _swindlerDetector.SwindlerExited += Stop;
    }

    private void OnDisable()
    {
        _swindlerDetector.SwindlerEntered -= Play;
        _swindlerDetector.SwindlerExited -= Stop;
    }

    private void Play()
    {
        _targetVolume = 1.0f;

        _alarm.StartChangingVolume(_targetVolume);
    }

    private void Stop()
    {
        _targetVolume = 0f;

        _alarm.StartChangingVolume(_targetVolume);
    }
}
