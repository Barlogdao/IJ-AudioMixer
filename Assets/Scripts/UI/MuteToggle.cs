using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteToggle : MonoBehaviour
{
    private Toggle _toggle;
    private IMutable _mutable;

    public void Initialize(IMutable mutable)
    {
        _toggle = GetComponent<Toggle>();
        _mutable = mutable;

        _toggle.isOn = _mutable.IsMuted == false;

        _toggle.onValueChanged.AddListener(ToggleMute);
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMute);
    }

    private void ToggleMute(bool isToggled)
    {
        bool isMuted = isToggled == false;

        _mutable.SetMuteValue(isMuted);
    }
}
