using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private AudioService _audioService;
    [SerializeField] private AudioSettings _audioSettings;

    private AudioMediator _audioMediator;

    private void Awake()
    {
        _audioMediator = new AudioMediator();

        _audioService.Initialize(_audioMediator);
        _audioSettings.Inititalize(_audioMediator);
    }
}
