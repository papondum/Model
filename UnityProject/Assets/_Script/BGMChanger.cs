using UnityEngine;
using System.Collections;

public class BGMChanger : MonoBehaviour {

	public AudioClip normalBGM;
	public AudioClip bossBGM;
	
	public void playBossBGM(){
		if (audio.clip != bossBGM) {
			audio.clip = bossBGM;
			audio.Play ();
		}
	}

}
