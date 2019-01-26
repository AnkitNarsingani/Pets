using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }
    public Sound[] sounds;
    AudioSource theme;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.clip = s.clip;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Did not find sound: " + name);
            return;
        }
        s.source.Play();
    }

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;

        [Range (0f, 1f)]
        public float volume;
        [Range (0.1f, 3f)]
        public float pitch;

        [HideInInspector] public AudioSource source;
    }
}
