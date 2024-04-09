using System;
using UnityEngine;

public class AudioMediator : MonoBehaviour
{
    private const string MasterVolumeData = nameof(MasterVolumeData);
    private const string MusicVolumeData = nameof(MusicVolumeData);
    private const string SoundVolumeData = nameof(SoundVolumeData);

    public AudioMediator()
    {
        MasterVolume = PlayerPrefs.GetFloat(MasterVolumeData, 1f);
        MusicVolume = PlayerPrefs.GetFloat(MusicVolumeData, 1f);
        SoundVolume = PlayerPrefs.GetFloat(SoundVolumeData, 1f);
    }

    public void Initialize()
    {
        MasterVolume = PlayerPrefs.GetFloat(MasterVolumeData, 1f);
        MusicVolume = PlayerPrefs.GetFloat(MusicVolumeData, 1f);
        SoundVolume = PlayerPrefs.GetFloat(SoundVolumeData, 1f);
    }

    public event Action<float> MasterVolumeChanged;
    public event Action<float> MusicVolumeChanged;
    public event Action<float> SoundVolumeChanged;

    public float MasterVolume { get; private set; }
    public float SoundVolume { get; private set; }
    public float MusicVolume { get; private set; }

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

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(MasterVolumeData, MasterVolume);
        PlayerPrefs.SetFloat(SoundVolumeData, SoundVolume);
        PlayerPrefs.SetFloat(MusicVolumeData, MusicVolume);
        PlayerPrefs.Save();
    }
}
