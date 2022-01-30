using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FadeAudioSource
{ 
    public static IEnumerator StartFade(AudioSource _audioSource, float _duration, float _targetVolume)
    {
        float currentTime = 0;
        float start = _audioSource.volume;

        while (currentTime < _duration)
        {
            currentTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(start, _targetVolume, currentTime / _duration);
            yield return null;
        }
        yield break;
    }
}
