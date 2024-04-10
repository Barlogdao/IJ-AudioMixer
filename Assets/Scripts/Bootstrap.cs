using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private AudioService _audioService;
    [SerializeField] private AudioMixerHandler _audioMixerHandler;
    [SerializeField] private AudioSettings _audioSettings;

    private void Awake()
    {
        _audioService.Initialize();
        _audioMixerHandler.Initialize(_audioService);
        _audioSettings.Inititalize(_audioService);
    }
}
