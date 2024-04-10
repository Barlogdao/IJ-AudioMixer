using System;
using UnityEngine;

public class AudioService : MonoBehaviour, IMutable
{
    private const string MasterVolumeData = nameof(MasterVolumeData);
    private const string MusicVolumeData = nameof(MusicVolumeData);
    private const string SoundVolumeData = nameof(SoundVolumeData);
    private const string MuteVolumeData = nameof(MuteVolumeData);

    public void Initialize()
    {
        MasterVolume = PlayerPrefs.GetFloat(MasterVolumeData, 1f);
        MusicVolume = PlayerPrefs.GetFloat(MusicVolumeData, 1f);
        SoundVolume = PlayerPrefs.GetFloat(SoundVolumeData, 1f);
        IsMuted = GetMuteValue();
    }

    public event Action<float> MasterVolumeChanged;
    public event Action<float> MusicVolumeChanged;
    public event Action<float> SoundVolumeChanged;
    public event Action MuteChanged;

    public float MasterVolume { get; private set; }
    public float SoundVolume { get; private set; }
    public float MusicVolume { get; private set; }
    public bool IsMuted { get; private set; }

    private void OnDestroy()
    {
        SetMuteValue();

        PlayerPrefs.SetFloat(MasterVolumeData, MasterVolume);
        PlayerPrefs.SetFloat(SoundVolumeData, SoundVolume);
        PlayerPrefs.SetFloat(MusicVolumeData, MusicVolume);
        PlayerPrefs.Save();
    }

    public void SetMasterVolume(float value)
    {
        MasterVolume = value;
        MasterVolumeChanged?.Invoke(MasterVolume);
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = value;
        MusicVolumeChanged?.Invoke(MusicVolume);
    }

    public void SetSoundVolume(float value)
    {
        SoundVolume = value;
        SoundVolumeChanged?.Invoke(SoundVolume);
    }

    public void SetMuteValue(bool isMuted)
    {
        IsMuted = isMuted;
        MuteChanged?.Invoke();
    }

    private bool GetMuteValue()
    {
        int value = PlayerPrefs.GetInt(MuteVolumeData, 0);

        return value != 0;
    }

    private void SetMuteValue()
    {
        PlayerPrefs.SetInt(MuteVolumeData, IsMuted ? 1 : 0);
    }
}
