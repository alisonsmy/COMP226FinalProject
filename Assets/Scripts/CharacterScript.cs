using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour 
{
	bool sprint, grounded;
	public Animator animator;
	float wantedYRotation;
	public float RotaionAmount = 5.0f;
	public float rotationSensitivity = 60.0f;
	Rigidbody charRigBody;
	public GameObject charObj;


	// Use this for initialization
	void Start () 
	{
		//animator = GameObject.GetComponent<Animator> ();
		charRigBody = charObj.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Sprint ();
		Walk ();
		Rotation ();

		/*if (Input.GetKeyDown (KeyCode.Space)) 
		{
			StartCoroutine ("BasicJump");
		}*/
	
	}

	IEnumerator BasicJump()
	{
		animator.SetBool ("jump", true);
		yield return new WaitForEndOfFrame();
		animator.SetBool("jump",false);
		StopCoroutine ("BasicJump");
	}

	IEnumerator SideStepRight()
	{
		animator.SetBool ("sideStepRight", true);
		yield return new WaitForEndOfFrame();
		animator.SetBool("sideStepRight",false);
		StopCoroutine ("SideStepRight");
	}
	IEnumerator Roll()
	{
		charRigBody.freezeRotation = true;
		animator.SetBool ("roll", true);
		yield return new WaitForEndOfFrame();
		animator.SetBool("roll",false);
		StopCoroutine ("Roll");
		charRigBody.freezeRotation = false;
	}

	void Walk()
	{
		animator.SetFloat ("walkForwardValue", 1); //WS/UPDOWN
		//animator.SetFloat("sideWalkValue",  Input.GetAxis("Horizontal"));//AD/LEFTRIGHT
		animator.SetBool("sprint", sprint); //shift
		//Debug.Log(animator.GetFloat("walkForwardValue"));
	}

	void Sprint()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift))
			sprint = true;
		if (Input.GetKeyUp (KeyCode.LeftShift))
			sprint = false;
	}

	void Rotation()
	{
		wantedYRotation += Input.GetAxis ("Mouse X") * Time.deltaTime * rotationSensitivity;
		transform.rotation = Quaternion.Euler (new Vector3 (0, wantedYRotation, 0));
	}

	void OnCollisionStay(Collision other)
	{
		foreach (ContactPoint contact in other.contacts) 
		{
			if(Vector3.Angle(contact.normal, Vector3.up) < 60.0f)
				grounded = true;
		}
	}
	
	void OnCollisionExit()
	{
		grounded = false;
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Triggered Action");
		if(other.tag == "JumpingWall")
		{
			Debug.Log ("Triggered Action - JumpWall");
			StartCoroutine ("BasicJump");
		}

		if(other.tag == "RightSideStep")
		{
			Debug.Log ("Triggered Action - RightSideStep");
			StartCoroutine ("SideStepRight");
		}

		if(other.tag == "UnderPass")
		{
			Debug.Log ("Triggered Action - Roll");
			StartCoroutine ("Roll");
		}

	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log ("Has left trigger.");
	}
		
}