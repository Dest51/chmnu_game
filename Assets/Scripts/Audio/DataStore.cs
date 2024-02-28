using UnityEngine;
public static class DataStore
{
    private const string SOUNDS_VOLUME_KEY = "SOUNDS_VOLUME_KEY";
    private const string MUSIC_VOLUME_KEY = "MUSIC_VOLUME_KEY";

    public static void SaveSoundsVolume(float value)
    {
        PlayerPrefs.SetFloat(SOUNDS_VOLUME_KEY, value);
    }

    public static void SaveMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, value);
    }

    public static float LoadSoundsVolume()
    {
        if (PlayerPrefs.HasKey(SOUNDS_VOLUME_KEY))
            return PlayerPrefs.GetFloat(SOUNDS_VOLUME_KEY);
        else
            return 1f;
    }

    public static float LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey(MUSIC_VOLUME_KEY))
            return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
        else
            return 1f;
    }
}
