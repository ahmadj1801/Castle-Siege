﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
	
	public string AudioName;
	
	public AudioClip clip;
	
	[Range(0f, 1f)]
	public float volume;
	
	public bool loop;
	
	[Range(.1f, 3f)]
	public float pitch;
	
	[HideInInspector]
	public AudioSource source;
}
