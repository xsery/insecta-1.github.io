using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour {

	GameObject player;
	Vector3 startPoint;
	Vector3 direction;
	Vector3 attackPosition;

	Rigidbody rbd;

	public float speed;
	bool canMove = true;
	Animator anim;

	// Use this for initialization
	void Awake () {
		rbd = GetComponent<Rigidbody> ();
		anim = GetComponentInChildren<Animator>();
		startPoint = rbd.transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
		attackPosition = new Vector3(0,0,8);


	}

	// Update is called once per frame
	void FixedUpdate () {
		if (canMove) {
			float step = (speed * Time.deltaTime);
			rbd.transform.position = Vector3.MoveTowards (rbd.transform.position, attackPosition, step);
			transform.LookAt (player.transform);
			/*
			if (rbd.transform.position.z == 0)
				rbd.transform.position = startPoint;

			*/
		}

		if (rbd.transform.position == attackPosition) {
			// num = Random.Range(0.1f, 3f);
			rbd.AddForce(rbd.transform.up * 20000 * Time.deltaTime);
			Debug.Log (rbd.transform.position +" || " + attackPosition);
		}

	}
}
