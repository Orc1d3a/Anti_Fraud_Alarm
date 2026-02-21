using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    public void StartChangingVolume(float goal)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolume(goal));
    }

    private IEnumerator ChangeVolume(float goal)
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
