using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuluHunter : MonoBehaviour {

    int speed = 1;
    public bool hunting;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("MainCharacter");
    }
	
	// Update is called once per frame
	void Update () {
		if (hunting)
        {
            Vector2 targetVelocity = new Vector2 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            Debug.Log(player.transform.position.x - transform.position.x);
            GetComponent<Rigidbody2D>().velocity = targetVelocity * speed;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "MainCharacter")
        {
            hunting = true;
            Debug.Log("hunting");
        }
    }
}
