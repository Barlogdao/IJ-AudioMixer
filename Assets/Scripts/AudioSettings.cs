using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Toggle _muteToggle;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    private AudioMediator _audioMediator;

    public void Inititalize(AudioMediator audioMediator)
    {
        _audioMediator = audioMediator;

        _muteToggle.isOn = _audioMediator.IsMuted == false;
        _masterSlider.value = _audioMediator.MasterVolume;
        _musicSlider.value = _audioMediator.MusicVolume;
        _soundSlider.value = _audioMediator.SoundVolume;

        _muteToggle.onValueChanged.AddListener(ToggleMute);
        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
    }

    private void OnDestroy()
    {
        _muteToggle.onValueChanged.RemoveListener(ToggleMute);
        _masterSlider.onValueChanged.RemoveListener(ChangeMasterVolume);
        _musicSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        _soundSlider.onValueChanged.RemoveListener(ChangeSoundVolume);
    }

    private void ChangeSoundVolume(float value)
    {
        _audioMediator.SetSoundVolume(value);
    }

    private void ChangeMusicVolume(float value)
    {
        _audioMediator.SetMusicVolume(value);
    }

    private void ChangeMasterVolume(float value)
    {
        _audioMediator.SetMasterVolume(value);
    }

    private void ToggleMute(bool isToggled)
    {
        _audioMediator.ToggleMute(isToggled);
    }
}
