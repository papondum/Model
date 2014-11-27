using UnityEngine;
using System.Collections;

public class ItemSpawnPoint : MonoBehaviour {

	public ItemRandomer itemRandomer;

	private float rotateSpeed = 120f;
	private float highDiv = 0.15f;

	private bool hasItem;

	void Update()
	{
		renderer.enabled = hasItem;
		transform.Rotate (new Vector3 (0, Time.deltaTime * rotateSpeed, 0));

		float y = transform.position.y + ( Mathf.Sin(Time.time) * highDiv * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, y , transform.position.z);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("Player") && hasItem) {
			itemRandomer.RandomItem();
			hasItem = false;
		}
	}

	public void SpawnBox(){
		hasItem = true;
	}
}
