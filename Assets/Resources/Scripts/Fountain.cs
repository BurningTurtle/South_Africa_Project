using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour {

	private Animator animator;
	public int karma = 0;
	[Header("Time in s")]
	[SerializeField] private float period;
	[SerializeField] private UIController uic;
	private int elapsedSinceAction;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		InvokeRepeating ("KarmaAction", 0, period);
		InvokeRepeating ("timeUntilAction", 0, 1);
	}

	void timeUntilAction() {
		if (elapsedSinceAction > period)
			elapsedSinceAction = 1;
		elapsedSinceAction += 1;
		//uic.actionLabel.text = (period - elapsedSinceAction + 1).ToString ();
	}
		
	void KarmaAction() {
		karma += 1;
		setState (karma);
	}

	public void setState(int state){
		animator.SetInteger ("state", state);
	}

	// Update is called once per frame
	void Update () {
	}
			
		
}
