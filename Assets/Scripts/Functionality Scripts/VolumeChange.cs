using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    public void Update()
    {
        setSliderValue(masterSlider, "masterVol");
        setSliderValue(musicSlider, "musicVol");
        setSliderValue(sfxSlider, "sfxVol");
    }

    public void SetMusicLevel(float _sliderValue)
    {
        mixer.SetFloat("musicVol", Mathf.Log10(_sliderValue) * 20);
    }

    public void setSFXLevel(float _sliderValue)
    {
        mixer.SetFloat("sfxVol", Mathf.Log10(_sliderValue) * 20);
    }

    public void setMasterLevel(float _sliderValue)
    {
        mixer.SetFloat("masterVol", Mathf.Log10(_sliderValue) * 20);
    }

    void setSliderValue(Slider _slider, string _name)
    {
        if (_slider == null) return;
        float value;
        mixer.GetFloat(_name, out value);
        value = Mathf.Pow(10, (value / 20));
        _slider.value = value;
        Debug.Log(value);
    }
}
