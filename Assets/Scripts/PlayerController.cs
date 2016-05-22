using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D myRigidbody;

	public int jumping;
	public bool grounded;
	public bool swimming;
	public LayerMask whatIsGround;
	public LayerMask whatIsWater;
	public LayerMask whatIsBlock;
	public Animator gameOverAnimator;


	private int groundDelay;
	private int counter;
	private float jumpAngle;
	private Vector3 lastPlayerPosition;
	private float rotateAngle;
	private Collider2D myCollider;

	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();

		myCollider = GetComponent<Collider2D>();


		myAnimator = GetComponent<Animator>();

		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (grounded) {
			groundDelay = 0;
			jumping = -1;
		}
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		swimming = Physics2D.IsTouchingLayers (myCollider, whatIsWater);

		if (Physics2D.IsTouchingLayers (myCollider, whatIsBlock)) {
			if (moveSpeed == 0) {
				return;
			}
			moveSpeed = 0;
			gameOverAnimator.SetTrigger ("GG");

		}


		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {


			if (swimming) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce * 2/3);
			}else if (grounded || groundDelay <= 1){
				jumping = 0;
//				jumpAngle = (Vector3.Angle (new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z), Vector3.up));
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				myAnimator.SetTrigger ("Jumped");
			}
		}

		if (grounded) {

			if (jumping != -1) {
				jumping = -1;
			} else {
				jumping = -1;
				Vector3 moveDirection = gameObject.transform.position - lastPlayerPosition; 
					
				if (moveDirection != Vector3.zero && counter % 5 == 0) {
					float angle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
					transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
					jumpAngle = angle;
					counter = 0;
				}
			}

		} else if(jumping<100 && jumping>=0 && counter%4==0){

			transform.rotation = Quaternion.AngleAxis(jumpAngle*(100-jumping)/100 ,Vector3.forward );


		}

		lastPlayerPosition = transform.position;
		counter++;
		groundDelay++;
		jumping++;

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);

	}
}
