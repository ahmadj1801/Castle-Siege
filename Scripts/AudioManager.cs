using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
	
	public Sound[] sounds;
	

    void Awake()
    {
        foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
    }
	
	void Start(){
		Play("Theme2");
	}

    public void Play(string n){
		Sound s = Array.Find(sounds, sound=> sound.AudioName == n);
		s.source.Play();
	}
	
	public void Stop(string n){
		Sound s = Array.Find(sounds, sound=> sound.AudioName == n);
		s.source.Stop();
	}
}
