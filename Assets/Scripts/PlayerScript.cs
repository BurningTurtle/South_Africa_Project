﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]

public class PlayerScript : MonoBehaviour {

	public float playerSpeed = 4f;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			animator.SetBool ("Walking", true);
		} else {
			animator.SetBool ("Walking", false);
		}
		Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		GetComponent<Rigidbody2D>().velocity=targetVelocity * playerSpeed;
	}
}
