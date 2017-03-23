using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	[SerializeField] private Text karmaLabel;
	[SerializeField] private Fountain fountain;
    [SerializeField] private Text positive, negative;


	// Use this for initialization
	void Start () {
        positive.CrossFadeAlpha(0f, 0f, false);
        negative.CrossFadeAlpha(0f, 0f, false);
    }
	
	// Update is called once per frame
	void Update () {
	    karmaLabel.text = fountain.karma.ToString ();
	}

    public void fadePositive()
    {
        StartCoroutine(fadePositiveE());
    }

    IEnumerator fadePositiveE()
    {
        positive.CrossFadeAlpha(1f, 2f, false);
        yield return new WaitForSeconds(2f);
        positive.CrossFadeAlpha(0f, 2f, false);
    }

    public void fadeNegative()
    {
        StartCoroutine(fadeNegativeE());
    }

    IEnumerator fadeNegativeE()
    {
        negative.CrossFadeAlpha(1f, 2f, false);
        yield return new WaitForSeconds(2f);
        negative.CrossFadeAlpha(0f, 2f, false);
    }


}
