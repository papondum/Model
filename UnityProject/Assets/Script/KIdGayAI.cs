using UnityEngine;
using System.Collections;

public class KIdGayAI : MonoBehaviour {

	public float moveSpeed = 1.3f;

	public float minDistance = 3f;
	public float maxDistance = 10f;
	public float distanceToStopFollowing = 0.6f;

	private KidGayAiState aiState;

	private Transform playerTransform;
	private Animator animator;

	enum KidGayAiState { Follow , Idle , RandomMove};

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		animator = this.GetComponent<Animator> ();

		aiState = KidGayAiState.Idle;
	}
	
	// Update is called once per frame
	void Update () {

		float currentDistance = Vector3.Distance (transform.position, playerTransform.position);

		if (currentDistance <= maxDistance) {
			aiState = KidGayAiState.Follow;
		}
		else{
			aiState = KidGayAiState.Idle;
		}

		if (aiState == KidGayAiState.Follow) {
			FollowPlayer();		
		}
		else if(aiState == KidGayAiState.Idle){
			Idle();
		}


	}

	void FollowPlayer()
	{
		float currentDistance = Vector3.Distance (transform.position, playerTransform.position);
		if ( currentDistance <= minDistance) {
			float interpolationRatio = 1 - ( (currentDistance-distanceToStopFollowing) / minDistance);
			float currentSpeed = Mathf.Lerp( 1.0f , 0.1f , interpolationRatio);
			animator.SetFloat("Speed" , currentSpeed);
			
		}
		else{
			animator.SetFloat("Speed" , 1f);
		}
		
		
		transform.LookAt (new Vector3 (playerTransform.position.x, transform.position.y, playerTransform.position.z));
		
		if (currentDistance > distanceToStopFollowing) {
			Vector3 move = transform.forward * moveSpeed * Time.deltaTime;
			transform.position += move;
		}
		
		//find direction
		Vector3 targetDirection = (playerTransform.position - transform.position).normalized;
		Vector3 perp = Vector3.Cross (transform.forward, targetDirection);
		float dir = Vector3.Dot (perp, transform.up);
		
		animator.SetFloat("Direction" ,dir);
	}
	void Idle()
	{
		animator.SetFloat("Speed" , 0f);
	}
}
