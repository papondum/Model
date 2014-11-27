using UnityEngine;
using System.Collections;

public class DildoItem : Item {

	public float duration;

	public override void Use ()
	{
		base.Use ();
		var player = GameObject.FindGameObjectWithTag("Player");
		var dildoPlayer = player.GetComponent<DildoPlayer> ();
		dildoPlayer.useDildo (duration);
	}

}
