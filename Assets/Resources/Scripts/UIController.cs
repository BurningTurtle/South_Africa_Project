using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	[SerializeField] private Text karmaLabel;
	[SerializeField] private Text actionLabel;
	[SerializeField] private Fountain fountain;
	public int karma = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("KarmaAction", 0, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		karmaLabel.text = karma.ToString ();
	}

	void KarmaAction() {
		karma += 1;
		fountain.setState (karma);
	}
}
