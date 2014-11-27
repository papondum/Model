using UnityEngine;
using System.Collections;

public class ItemSpawnPoint : MonoBehaviour {


	private GameObject currentItem; 

	public void SpawnItem(GameObject item)
	{
		if (currentItem != null) {
			Destroy (currentItem);
		}
		Instantiate( item, transform.position , transform.rotation);
		currentItem = item;
	}
}
