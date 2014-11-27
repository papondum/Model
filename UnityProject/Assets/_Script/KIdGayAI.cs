using UnityEngine;
using System.Collections;

public class KIdGayAI : MonoBehaviour {

	public float moveSpeed = 1.3f;

	public float minDistance = 3f;
	public float maxDistance = 10f;
	public float distanceToStopFollowing = 0.6f;

	public bool isBoss;
	private BGMChanger bgmChanger;

	private KidGayAiState aiState;

	private Transform playerTransform;
	private Animator animator;

	enum KidGayAiState { Follow , Idle , RandomMove};

	
	private float tmpSpeed;
	private float changeSpeedTimer;

	private GameObject player;
	private DildoPlayer dildoPlayer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		dildoPlayer = player.GetComponent<DildoPlayer> ();

		playerTransform = player.transform;
		animator = this.GetComponent<Animator> ();

		aiState = KidGayAiState.Idle;
		tmpSpeed = moveSpeed;

		bgmChanger = GameObject.FindGameObjectWithTag("BGMAudioSource").GetComponent<BGMChanger>();
	}
	
	// Update is called once per frame
	void Update () {

		float currentDistance = Vector3.Distance (transform.position, playerTransform.position);

		if (currentDistance <= maxDistance) {
			aiState = KidGayAiState.Follow;

			if(isBoss){
				bgmChanger.playBossBGM();
			}
		}
		else{
			aiState = KidGayAiState.Idle;
		}


		if (dildoPlayer.isUsingDildo()) {
			aiState = KidGayAiState.Idle;
		}


		if (aiState == KidGayAiState.Follow) {
			FollowPlayer();		
		}
		else if(aiState == KidGayAiState.Idle){
			Idle();
		}


		//speed timer
		changeSpeedTimer -= Time.deltaTime;
		if (changeSpeedTimer < 0) {
			moveSpeed = tmpSpeed;
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
	
	public void ChangeSpeed(float duration,float speedFactor)
	{
		moveSpeed = tmpSpeed;
		tmpSpeed = moveSpeed;
		
		moveSpeed = moveSpeed * speedFactor;
		changeSpeedTimer = duration;
	}
}
