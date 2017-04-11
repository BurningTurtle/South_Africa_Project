using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	// Use this for initialization
	void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name == "MainCharacter")
        {
            switch(this.transform.name)
            {
                case "beehive0":
                    other.transform.position = new Vector2(10, 36.5f);
                    break;
                case "exit1":
                    other.transform.position = new Vector2(4, 8.5f);
                    break;
                case "beehive1":
                    other.transform.position = new Vector2(60, 36.5f);
                    break;
                case "exit2":
                    other.transform.position = new Vector2(16, 8.5f);
                    break;
            }
        }
    }
}
