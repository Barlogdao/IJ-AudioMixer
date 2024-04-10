using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private MuteToggle _muteToggle;

    private AudioService _audioService;

    public void Inititalize(AudioService audioService)
    {
        _audioService = audioService;

        _muteToggle.Initialize(_audioService);

        _masterSlider.value = _audioService.MasterVolume;
        _musicSlider.value = _audioService.MusicVolume;
        _soundSlider.value = _audioService.SoundVolume;

        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
    }

    private void OnDestroy()
    {
        _masterSlider.onValueChanged.RemoveListener(ChangeMasterVolume);
        _musicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        _soundSlider.onValueChanged.RemoveListener(ChangeSoundVolume);
    }

    private void ChangeSoundVolume(float value) => _audioService.SetSoundVolume(value);

    private void ChangeMusicVolume(float value) => _audioService.SetMusicVolume(value);

    private void ChangeMasterVolume(float value) => _audioService.SetMasterVolume(value);

}
