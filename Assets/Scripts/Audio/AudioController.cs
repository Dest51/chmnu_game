using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioSource _sourceSFX;
    private static AudioSource _sourceMusic;
    private static AudioSource _sourceRandomPitchSFX;
    private static float _musicVolume = 1f;
    private static float _sfxVolume = 1f;
    private static AudioClip[] _musicClips = null;
    private static AudioClip[] _soundClips = null;

    public static void Init()
    {
        GameObject gameObject = new GameObject("AudioController");
        DontDestroyOnLoad(gameObject);
        _sourceSFX = gameObject.AddComponent<AudioSource>();
        _sourceMusic = gameObject.AddComponent<AudioSource>();
        _sourceRandomPitchSFX = gameObject.AddComponent<AudioSource>();

        Dictionary<string, AudioClip> dictionary = new Dictionary<string, AudioClip>();

        _musicClips = Resources.LoadAll<AudioClip>("Audio/Musics");
        _soundClips = Resources.LoadAll<AudioClip>("Audio/Sounds");

        for (int i = 0; i < _musicClips.Length; i++)
        {
            dictionary.Add(_musicClips[i].name, _musicClips[i]);
        }

        for (int i = 0; i < _soundClips.Length; i++)
        {
            dictionary.Add(_soundClips[i].name, _soundClips[i]);
        }

    }

    public static AudioClip GetSound(string clipName)
    {
        for (int i = 0; i < _soundClips.Length; i++)
        {
            if (_soundClips[i].name == clipName)
            {
                return _soundClips[i];
            }
        }
        Debug.LogError("Error: clip not found");
        return null;

    }

    public static AudioClip GetMusic(string clipName)
    {
        for (int i = 0; i < _musicClips.Length; i++)
        {
            if (_musicClips[i].name == clipName)
            {
                return _musicClips[i];
            }
        }
        Debug.LogError("Error: clip not found");
        return null;

    }

    public static void PlaySound(string name)
    {
        _sourceSFX.PlayOneShot(GetSound(name), _sfxVolume);
    }

    public static void PlayRandomPichSound(string name)
    {
        _sourceRandomPitchSFX.pitch = Random.Range(0.73f, 1.3f);
        _sourceRandomPitchSFX.PlayOneShot(GetSound(name), _sfxVolume);
    }

    public static void StopSound()
    {
        _sourceSFX.Stop();
    }

    public static void StopMusic()
    {
        _sourceMusic.Stop();
    }

    public static void PlayMusicOnce(string name)
    {
        _sourceMusic.Stop();
        _sourceMusic.clip = GetMusic(name);
        _sourceMusic.volume = _musicVolume;
        _sourceMusic.Play();
    }

    public static void PlayMusicLoop(string name)
    {
        _sourceMusic.Stop();
        _sourceMusic.clip = GetMusic(name);
        _sourceMusic.volume = _musicVolume;
        _sourceMusic.loop = true;
        _sourceMusic.Play();
    }

    public static void SetSoundVolume(float volume)
    {
        if(volume > 1)
            volume = 1;

        DataStore.SaveSoundsVolume(volume);
        _sfxVolume = DataStore.LoadSoundsVolume();
    }

    public static void SetMusicVolume(float volume)
    {
        if (volume > 1)
            volume = 1;

        DataStore.SaveMusicVolume(volume);
        _musicVolume = DataStore.LoadMusicVolume();
    }


}
