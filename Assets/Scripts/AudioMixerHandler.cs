using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerHandler : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);
    private const string SoundVolume = nameof(SoundVolume);

    private const float ZeroValue = 0f;

    [SerializeField] private AudioMixer _audioMixer;

    private AudioService _audioMediator;
    private float _minVolume = -80f;

    public void Initialize(AudioService audioMediator)
    {
        _audioMediator = audioMediator;
    }

    private void Start()
    {
        SetVolumes();

        _audioMediator.MasterVolumeChanged += OnMasterVolumeChanged;
        _audioMediator.MusicVolumeChanged += OnMusicVolumeChanged;
        _audioMediator.SoundVolumeChanged += OnSoundVolumeChanged;
        _audioMediator.MuteChanged += OnMuteChanged;
    }



    private void OnDestroy()
    {
        _audioMediator.MasterVolumeChanged -= OnMasterVolumeChanged;
        _audioMediator.MusicVolumeChanged -= OnMusicVolumeChanged;
        _audioMediator.SoundVolumeChanged -= OnSoundVolumeChanged;
        _audioMediator.MuteChanged -= OnMuteChanged;
    }

    private void OnMasterVolumeChanged(float value) => SetVolume(MasterVolume, value);

    private void OnMusicVolumeChanged(float value) => SetVolume(MusicVolume, value);

    private void OnSoundVolumeChanged(float value) => SetVolume(SoundVolume, value);

    private void OnMuteChanged() => SetVolumes();

    private void SetVolumes()
    {
        SetVolume(MasterVolume, _audioMediator.MasterVolume);
        SetVolume(MusicVolume, _audioMediator.MusicVolume);
        SetVolume(SoundVolume, _audioMediator.SoundVolume);
    }

    private void SetVolume(string channel, float value)
    {
        float volume = _audioMediator.IsMuted ? _minVolume : ConvertToDecibel(value);

        _audioMixer.SetFloat(channel, volume);
    }

    private float ConvertToDecibel(float value)
    {
        if (Mathf.Approximately(value, ZeroValue))
        {
            return _minVolume;
        }

        float decibelMultiplier = 20;

        return Mathf.Log10(value) * decibelMultiplier;
    }
}