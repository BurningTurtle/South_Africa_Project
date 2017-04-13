using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]

public class PlayerScript : MonoBehaviour {

	public float playerSpeed = 4f;
	private Animator animator;
	public MainSceneController msc;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		//transform.position = new Vector2 (msc.gridCols / 2, 1);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.Euler (0, 0, 0); 
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			animator.SetBool ("Walking", true);
		} else {
			animator.SetBool ("Walking", false);
		}
		Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		GetComponent<Rigidbody2D>().velocity=targetVelocity * playerSpeed;
	}
}
