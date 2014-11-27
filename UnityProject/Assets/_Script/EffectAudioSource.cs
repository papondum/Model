using UnityEngine;
using System.Collections;

public class EffectAudioSource : MonoBehaviour {


	public void PlayEffect(AudioClip sound)
	{
		audio.PlayOneShot (sound);
	}

}
