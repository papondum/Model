using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public CharacterController characterController;

	public float turnSpeed = 90.0f;
	public float gravity = 9.81f;
	public float jumpSpeed = 5f;
	public float jumpAcceleratingSpeed = 3.5f;
	public float jumpDeceleratingSpeed = 1.8f;

	public float jumpBurstSpeed = 3.7f;
	public float moveSpeed = 5.0f;

	private float jumpDelay = 3.5f;
	private float jumpAnimationDelay = 2f;
	private float jumpUpAnimationWaitTime = 1.1f;

	private bool isJump;
	private float currentJumpDelay;
	private float currentJumpTime;
	private float currentJumpUpWaitTime;

	enum JumpState { NotJump,Begin,Jump,Jumped,FinishJump};
	private JumpState jumpState;



	private float ySpeed;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();

		isJump = false;
		jumpState = JumpState.NotJump;
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		animator.SetFloat ("Speed", inputY);

		//jump animator manage delay
		if (isJump) {
			currentJumpDelay -= Time.deltaTime;
			currentJumpTime -= Time.deltaTime;
			currentJumpUpWaitTime -= Time.deltaTime;

			if(currentJumpUpWaitTime <= 0 && jumpState == JumpState.Begin){
				jumpState = JumpState.Jump;
			}
			if (currentJumpTime <= 0) {
				animator.SetBool ("Jump", false);
				jumpState = JumpState.FinishJump;
			}
			if(currentJumpDelay <= 0){
				isJump = false;
				jumpState = JumpState.NotJump;
			}

		}


		if (Input.GetKeyDown (KeyCode.Space) && !isJump && inputY >= 0.99f) {
			animator.SetBool("Jump",true);

			currentJumpDelay = jumpDelay;
			currentJumpTime = jumpAnimationDelay;
			currentJumpUpWaitTime = jumpUpAnimationWaitTime;

			isJump = true;
			jumpState = JumpState.Begin;
		}

		if (!characterController.isGrounded) {
			ySpeed -= gravity * Time.deltaTime;
		}
		else{
			ySpeed = 0;
			if(jumpState == JumpState.Jump){
				ySpeed = jumpSpeed;
				jumpState = JumpState.Jumped;
			}
		}
	
		//rotate

		Vector3 vel = transform.forward * moveSpeed * inputY;

		if (jumpState == JumpState.Begin || jumpState == JumpState.Jump) {
			vel = transform.forward * jumpAcceleratingSpeed;
		}
		else if (jumpState == JumpState.Jumped) {
			vel = transform.forward * jumpBurstSpeed;
		}
		else if( jumpState == JumpState.FinishJump){
			vel = transform.forward * jumpDeceleratingSpeed;

		}
		else if ( jumpState == JumpState.NotJump){
			this.transform.Rotate (0, inputX * turnSpeed * Time.deltaTime, 0);

			float velMoveSpeed = inputY < 0f ? moveSpeed*0.7f : moveSpeed; //walk forward or backward ( back speed = 0.7*speed)
			vel = transform.forward * velMoveSpeed * inputY;
		}

		vel.y = ySpeed;
		characterController.Move( vel * Time.deltaTime );
	}

}







