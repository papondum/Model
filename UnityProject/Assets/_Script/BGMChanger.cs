using UnityEngine;
using System.Collections;

public class BGMChanger : MonoBehaviour {

	public AudioClip normalBGM;
	public AudioClip bossSound;
	public AudioClip bossBGM;

	private bool isBoossed;
	public void playBossBGM(){
		if (!isBoossed) {
			isBoossed = true;
			audio.clip = bossSound;
			audio.loop = false;
			audio.Play();
			StartCoroutine( Wait(bossSound.length) );
		}
	}

	IEnumerator Wait(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		audio.clip = bossBGM;
		audio.loop = true;
		audio.Play ();
	}	     

}
