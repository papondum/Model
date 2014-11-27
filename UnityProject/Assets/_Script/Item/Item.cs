using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip [] sound;
	public Sprite Icon;

	public virtual void Use()
	{
		int soundIndex = Random.Range (0, sound.Length);
		audioSource.PlayOneShot (sound [soundIndex]);
	}
}
