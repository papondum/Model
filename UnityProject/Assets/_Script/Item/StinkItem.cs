using UnityEngine;
using System.Collections;

public class StinkItem : Item {

	public float speedFactor = 0.5f;
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
