using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuluHunterWeapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector2(0.89f, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Zulu").GetComponent<ZuluHunter>().hunting)
        {
            transform.localPosition = new Vector2 (0.81f, 0.49f);
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
	}
}
