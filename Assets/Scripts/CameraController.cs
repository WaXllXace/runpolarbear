using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;
	private float distanceUpAndDown;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		distanceUpAndDown = thePlayer.transform.position.y - lastPlayerPosition.y;

		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y + distanceUpAndDown, transform.position.z);

		lastPlayerPosition = thePlayer.transform.position;
	}
}
