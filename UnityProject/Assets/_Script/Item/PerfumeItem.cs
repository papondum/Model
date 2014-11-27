using UnityEngine;
using System.Collections;

public class PerfumeItem : Item {
	
	public float Duration = 7f;
	public float speedFactor = 1.5f;

	public override void Use ()
	{
		base.Use ();

		var enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (var enemy in enemies) {
			KIdGayAI gayAi = enemy.GetComponent<KIdGayAI>();
			gayAi.ChangeSpeed(Duration,speedFactor);
		}
	}
}
