using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;
    public Sound[] musics;

    public Mood mood;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;

            s.audioSource.playOnAwake = false;

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }

        foreach (Sound s in musics)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;

            s.audioSource.playOnAwake = false;

            s.audioSource.loop = s.loop;

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }

        mood = Mood.chill;

    }

    public void Play(string name, float pitch = (1), float volume = (0f))
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //Sound s = sounds.Find(s => s.name == name);  

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.audioSource.pitch = pitch;
        s.audioSource.Play();
    }
    public void Stop(string name, float pitch = (1))
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.audioSource.pitch = pitch;
        s.audioSource.Stop();
    }
    
    private Sound FindSounds()
    {
        return Array.Find(sounds, sound => sound.name == name);
    }

    public void PlayMusic(string name)
    {

        Sound m = Array.Find(musics, sound => sound.name == name);

        if (m == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        m.audioSource.Play();

    }
    public void StopMusic(string name)
    {

        Sound m = Array.Find(musics, sound => sound.name == name);

        if (m == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        m.audioSource.Stop();

    }


    public IEnumerator SwitchMusic()
    {
        if (mood == Mood.chill)
        {
            mood = Mood.none;
            musics[0].audioSource.Stop();

            sounds[1].audioSource.Play();
            yield return new WaitForSeconds(sounds[1].audioSource.clip.length);

            sounds[2].audioSource.Play();
            yield return new WaitForSeconds(sounds[2].audioSource.clip.length);

            musics[1].audioSource.Play();
            mood = Mood.punk;
        }
        else if (mood == Mood.punk)
        {
            mood = Mood.none;
            musics[1].audioSource.Stop();

            sounds[1].audioSource.Play();
            yield return new WaitForSeconds(sounds[1].audioSource.clip.length);

            sounds[2].audioSource.Play();
            yield return new WaitForSeconds(sounds[2].audioSource.clip.length);

            musics[0].audioSource.Play();
            mood = Mood.chill;
        }
    }

}

