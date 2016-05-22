using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartingLight : MonoBehaviour {

	public float lightIntensity;
	public Light lightComp;

	// Use this for initialization
	void Start () {
		lightComp = GetComponent<Light> ();
		lightComp.color = Color.white;
		transform.position = new Vector3(0, 0, -15);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time <= 4) {
			lightComp.intensity = Time.time / 4 * lightIntensity;
		} else if (Time.time >= 6 && Time.time <= 8) {
			lightComp.intensity = (8 - Time.time) / 2 * lightIntensity;
		} else if (Time.time > 8) {
			SceneManager.LoadScene ("Menu1");
		}
	}
}
