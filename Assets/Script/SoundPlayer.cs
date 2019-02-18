using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
	public static SoundPlayer instance
	{
		get
		{
			if(!_instance)
			{
				GameObject soundPlayerObject = new GameObject("SoundPlayer");
				_instance = soundPlayerObject.AddComponent<SoundPlayer>();
				_instance.bgm = soundPlayerObject.AddComponent<AudioSource>();
				_instance.se = soundPlayerObject.AddComponent<AudioSource>();
			}
			return _instance;
		}
	}

	private static SoundPlayer _instance;
	private AudioSource bgm;
	private AudioSource se;
	private float volumeUpperLimit = 1.0f;
	private float volumeLowerLimit = 0.6f;
	private float pitchUpperLimit = 1.3f;
	private float pitchLowerLimit = 0.7f;

	private void Start()
	{
		if(_instance != this) Destroy(this);
	}

	public void playBGM(AudioClip au)
	{
		if(bgm.clip != au) bgm.clip = au;
		bgm.Play();
	}

	public void playSE(AudioClip au)
	{
		if(se.clip != au) se.clip = au;
		se.volume = Random.Range(volumeLowerLimit, volumeUpperLimit);
		se.pitch = Random.Range(pitchLowerLimit, pitchUpperLimit);
		se.Play();
	}
}