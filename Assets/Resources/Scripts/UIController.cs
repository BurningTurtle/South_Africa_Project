using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	[SerializeField] private Text karmaLabel;
	[SerializeField] private Fountain fountain;
	public Text actionLabel;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		karmaLabel.text = fountain.karma.ToString ();
	}


}
