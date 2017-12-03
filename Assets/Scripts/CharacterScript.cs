using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

	public Vector3 pos1, pos2;
	public float speed;
	public float oldPosition = 0.0f;

	// Use this for initialization
	void Start () {
		oldPosition = transform.position.z; //we want to keep track of how far char goes on the z axis, since that's the direction it is walking
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Time.fixedTime == 2)
		{
			GetComponent<Animation>().Play("Male2_A7_Crouch");
		}
		if (Time.fixedTime == 4)
		{
			GetComponent<Animation>().Play("Male2_B1_StandToWalk");
		} */

		/*if (transform.position.z == oldPosition) {
			GetComponent<Animation> ().Play ("Male2_A7_Crouch");
		}*/
	}
}