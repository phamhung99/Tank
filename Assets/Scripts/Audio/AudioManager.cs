using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{

	public Sound[] sounds;
	private static List<Sound> staticSounds;
       
	void Awake () 
	{
		staticSounds = new List<Sound>();
 
		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
 
			s.source.loop = s.loop;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
 
			staticSounds.Add(s);
		}       
	}

	public static void MuteMusic(string name) 
	{
		foreach (Sound s in staticSounds) 
		{
			if (s.name == name) {
				s.source.volume = 0;
				return;
			}
		}
	}

	public static void UnmuteMusic(string name) 
	{
		foreach (Sound s in staticSounds) 
		{
			if (s.name == name) 
			{
				s.source.volume = 0.65f;
				return;
			}
		}
	}
 
	public static void Play(string name) 
	{
		foreach (Sound s in staticSounds) 
		{
			if (s.name == name) {
				s.source.Play();
				return;
			}
		}
	}

	public static bool CheckPlaying(string name)
	{
		foreach (Sound s in staticSounds)
		{
			if (s.name == name)
			{
				if(s.source.isPlaying) return true;
				else return false;
				
				
			}
		}
		return false;
	}
       
	public static void Stop(string name) 
	{
		foreach (Sound s in staticSounds) 
		{
			if (s.name == name) 
			{
				s.source.Stop();
				return;
			}
		}
	}
}
