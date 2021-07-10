using System;
using UnityEngine;
using UnityEngine.Audio;
using Yarn.Unity;

public class SoundManager : MonoBehaviour
{

    public SFX[] sfxList; 
    public Music[] musicList;
    public Ambience[] ambList;

    public DialogueRunner dr;

    /// Loads all of the SFX, ambience, and music in a given scene. Is there a huge potential memory leak?
    void Awake() 
    {
        foreach (SFX s in sfxList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }

        foreach (Music m in musicList)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
            m.source.loop = true;
        }

        foreach (Ambience a in ambList)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.loop = true;
        }
    }

    /// These functions find the string name of a given array and play the associated sound.
    public void PlaySFX (string name)
    {
        SFX s = Array.Find(sfxList, sfx => sfx.name == name);
        s.source.Play();
    }

    public void PlayMusic (string name)
    {
        Music m = Array.Find(musicList, music => music.name == name);
        m.source.Play();
    }

    public void PlayAmb (string name)
    {
        Ambience a = Array.Find(ambList, ambience => ambience.name == name);
        a.source.Play();
    }

    /// These functions tell the dialogue runner what to do when it gets to a command.
    private void playSFX(string[] parameters) 
    {
        PlaySFX(parameters[0]);
        Debug.Log("Played SFX " + parameters[0]);
    }

     private void playMusic(string[] parameters) 
    {
        PlayMusic(parameters[0]);
        Debug.Log("Played Music " + parameters[0]);
    }

     private void playAmb(string[] parameters) 
    {
        PlayAmb(parameters[0]);
        Debug.Log("Played Ambience " + parameters[0]);
    }

    void Start() 
    {
        dr.AddCommandHandler("playsfx", playSFX);
        dr.AddCommandHandler("playmusic", playMusic);
        dr.AddCommandHandler("playambience", playAmb);
       
    }    
}
