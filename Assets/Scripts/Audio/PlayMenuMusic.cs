using UnityEngine;

public class PlayMenuMusic : MonoBehaviour
{
    private void Awake()
    {
        //AudioController.SetMusicVolume(0.4f);
        AudioController.PlayMusicLoop("menuMusic");
    }

}
