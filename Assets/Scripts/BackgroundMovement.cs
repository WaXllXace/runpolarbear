using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	public PlayerController thePlayer;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;
	private float distanceUpAndDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		distanceUpAndDown = thePlayer.transform.position.y - lastPlayerPosition.y;
		distanceToMove = distanceToMove *9/10;
		distanceUpAndDown = distanceUpAndDown * 10 / 11;

		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y + distanceUpAndDown, transform.position.z);

		lastPlayerPosition = thePlayer.transform.position;

	}
}
