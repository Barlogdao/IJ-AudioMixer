using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    private const string Master = nameof(Master);
    private const string Music = nameof(Music);
    private const string Sound = nameof(Sound);

    public AudioMixer _audioMixer;

    private float _minVolume = -80f;
    private float _maxVolume = 0f;

    private bool _isMuted;
    private int MuteModifier => _isMuted ? 0 : 1;

    private AudioMediator _audioMediator;

    public void Initialize(AudioMediator audioMediator)
    {
        _audioMediator = audioMediator;
        _audioMediator.MasterVolumeChanged += OnMasterVolumeChanged;
        _audioMediator.MusicVolumeChanged += OnMusicVolumeChanged;
        _audioMediator.SoundVolumeChanged += OnSoundVolumeChanged;
    }

    private void OnDestroy()
    {
        _audioMediator.MasterVolumeChanged -= OnMasterVolumeChanged;
        _audioMediator.MusicVolumeChanged -= OnMusicVolumeChanged;
        _audioMediator.SoundVolumeChanged -= OnSoundVolumeChanged;
    }

    private void OnSoundVolumeChanged(float value)
    {
        float volume = ConvertSliderValue(value);

        _audioMixer.SetFloat(Sound, volume);
    }

    private void OnMusicVolumeChanged(float value)
    {
        float volume = ConvertSliderValue(value);

        _audioMixer.SetFloat(Music, volume);
    }

    private void OnMasterVolumeChanged(float value)
    {
        float volume = ConvertSliderValue(value);

        _audioMixer.SetFloat(Master, volume);
    }

    public void ToogleVolume(bool isToggleOn)
    {
        _isMuted = isToggleOn;
        if (_isMuted)
        {
            _muted.TransitionTo(0.1f);

        }
        else
        {
            _normal.TransitionTo(0.1f);

        }
    }

    public void SetMasterVolume(float sliderValue)
    {
        float volume = ConvertSliderValue(sliderValue);

        _audioMixer.SetFloat(Master, volume);
    }

    private float ConvertSliderValue(float value)
    {
        return Mathf.Lerp(_minVolume, _maxVolume, value);
    }

    private void OnDestroy()
    {
        _audioMediator.MasterVolumeChanged -= OnMasterVolumeChanged;
        _audioMediator.MusicVolumeChanged -= OnMusicVolumeChanged;
        _audioMediator.SoundVolumeChanged -= OnSoundVolumeChanged;
    }
}
