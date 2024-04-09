using UnityEngine;
using UnityEngine.Audio;

public class AudioService : MonoBehaviour
{
    private const string Master = nameof(Master);
    private const string Music = nameof(Music);
    private const string Sound = nameof(Sound);

    [SerializeField] private AudioMixer _audioMixer;

    private AudioMediator _audioMediator;

    private float _minVolume = -80f;
    private float _maxVolume = 0f;

    public void Initialize(AudioMediator audioMediator)
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

    private void OnMasterVolumeChanged(float value) => SetVolume(Master, value);

    private void OnMusicVolumeChanged(float value) => SetVolume(Music, value);

    private void OnSoundVolumeChanged(float value) => SetVolume(Sound, value);

    private void OnMuteChanged() => SetVolumes();

    private void SetVolumes()
    {
        SetVolume(Master, _audioMediator.MasterVolume);
        SetVolume(Music, _audioMediator.MusicVolume);
        SetVolume(Sound, _audioMediator.SoundVolume);
    }

    private void SetVolume(string channel, float value)
    {
        float volume = _audioMediator.IsMuted ? _minVolume : ConvertToDecibel(value);

        _audioMixer.SetFloat(channel, volume);
    }

    private float ConvertToDecibel(float value)
    {
        return Mathf.Lerp(_minVolume, _maxVolume, value);
    }
}
