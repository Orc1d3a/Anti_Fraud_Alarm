using System.Collections;
using UnityEngine;

public class AlarmSoundController : MonoBehaviour
{
    [SerializeField] private SwindlerDetector _swindlerDetector;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    private float _targetVolume = 0;

    private void OnEnable()
    {
        _swindlerDetector.SwindlerEnter += Play;
        _swindlerDetector.SwindlerExit += Stop;
    }

    private void OnDisable()
    {
        _swindlerDetector.SwindlerEnter -= Play;
        _swindlerDetector.SwindlerExit -= Stop;
    }

    private void Play()
    {
        _targetVolume = 1.0f;

        ChangeCoroutineGoal();
    }

    private void Stop()
    {
        _targetVolume = 0f;

        ChangeCoroutineGoal();
    }

    private void ChangeCoroutineGoal()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(VolumeChanger(_targetVolume));
    }

    private IEnumerator VolumeChanger(float goal)
    {
        WaitForSeconds wait;

        float period = 0.1f;
        float step = 0.05f;

        wait = new WaitForSeconds(period);

        while (Mathf.Abs(_audioSource.volume - goal) > 0.01f)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, goal, step);

            yield return wait;
        }
    }
}
