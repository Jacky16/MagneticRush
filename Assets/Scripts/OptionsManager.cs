using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioMixer audiomixer;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSounds;
    float volumeMusic = 0.75f;
    float volumeSounds = 0.75f;
    private void Start()
    {
        LoadValuesAudio();
        LoadSliders();
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
    public void SaveValuesAudio()
    {
        PlayerPrefs.SetFloat("audioMusicValue", volumeMusic);
        PlayerPrefs.SetFloat("audioSoundValue", volumeSounds);
    }
    public void LoadValuesAudio()
    {
        volumeMusic = PlayerPrefs.GetFloat("audioMusicValue", 0.75f);
        volumeSounds = PlayerPrefs.GetFloat("audioSoundValue", 0.75f);

        audiomixer.SetFloat("Music_Volume", volumeMusic);
        audiomixer.SetFloat("SFX_Volume", volumeSounds);
    }

    public void LoadSliders()
    {
        sliderMusic.value = volumeMusic;
        sliderSounds.value = volumeSounds;
    }

    public void OnChangeMusicVolume(float _sliderValue)
    {
        audiomixer.SetFloat("Music_Volume", Mathf.Log10(_sliderValue) * 20);
        volumeMusic = _sliderValue;
    }
    public void OnChangeSoundVolume(float _sliderValue)
    {
        audiomixer.SetFloat("SFX_Volume", Mathf.Log10(_sliderValue) * 20);
        volumeSounds = _sliderValue;
    }
}
