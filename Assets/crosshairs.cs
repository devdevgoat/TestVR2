
using UnityEngine;
using UnityEngine.UI;

public class crosshairs : MonoBehaviour {

	public Camera cam;
	public GameObject hud;
	public Text targetText;
	public GameObject player;
	public float speed;

	private bool hasTarget;
	private bool isLockedOn;
	private Transform target; 
	private Vector3 lastKnownCoords;

	private bool isAttacking;
	// Update is called once per frame
	void Update () {
		scanForTargets();
		if(isLockedOn){
			if(Vector3.Distance(player.transform.position, lastKnownCoords) > .1f) { 
						float step = speed * Time.deltaTime;
         				player.transform.position = Vector3.MoveTowards(player.transform.position, lastKnownCoords, step);
					
						targetText.text = "Locked on! Approaching...";
					} else {
						isLockedOn = false;
					}

		}

		if(Input.GetButtonDown("Fire1") && hasTarget){
			isLockedOn = true;
			lastKnownCoords = target.position;
		}

	}

	void scanForTargets() {
		RaycastHit hit;
		if(Physics.Raycast(cam.transform.position,cam.transform.forward, out hit)){
			//Debug.Log(hit.transform.name);
			targetText.text = hit.transform.name;
			hasTarget = true;
			target = hit.transform;
		} else {
			targetText.text = "Searching...";
			hasTarget = false;
		}
	}
}
