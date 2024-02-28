using UI;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MovePanel
{
    [SerializeField] private Slider _musicSlider = null;
    [SerializeField] private Slider _soundSlider = null;
    [SerializeField] private Button _clousedButton = null;

    public void SetMusicVolume(float value)
    {
        AudioController.PlayMusicLoop("menuMusic");
        AudioController.SetMusicVolume(value);
    }

    public void SetSoundVolume(float value)
    {
        AudioController.SetSoundVolume(value);
    }

    private void OnEnable()
    {
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _soundSlider.onValueChanged.AddListener(SetSoundVolume);
        _clousedButton.onClick.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
        _soundSlider.onValueChanged.RemoveListener(SetSoundVolume);
        _clousedButton.onClick.RemoveListener(HidePanel);
    }

}
