using UI;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuHUD : MonoBehaviour
{
    [SerializeField] private Button _settingsButton = null;
    [SerializeField] private Button _exitButton = null;
    [SerializeField] private Button _aboutButton = null;
    [SerializeField] private Button _donateButton = null;
    [SerializeField] private MovePanel _movePanel = null;

    private void Awake()
    {
        AudioController.PlayMusicLoop("menuMusic");
    }
    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(ShowSettingsPanel);
        _exitButton.onClick.AddListener(Exit);
        _aboutButton.onClick.AddListener(OpenURLAbout);
        _donateButton.onClick.AddListener(OpenURLDonate);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(ShowSettingsPanel);
        _exitButton.onClick.RemoveListener(Exit);
        _aboutButton.onClick.RemoveListener(OpenURLAbout);
        _donateButton.onClick.RemoveListener(OpenURLDonate);
    }

    public void ShowSettingsPanel()
    {
        _movePanel.ShowPanel();
    }

    public void OpenURLAbout()
    {
       Application.OpenURL("https://docs.unity3d.com/Manual/index.html");
    }

    public void OpenURLDonate()
    {
        Application.OpenURL("https://donatello.to/");
    }


    public void Exit()
    {
        PlayerDataStore.ClearPrefs();
        Application.Quit();
    }
}
