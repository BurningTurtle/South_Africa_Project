using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour {

    public int speed;
    Rigidbody2D rigidbody;
    bool walking;

    // Use this for initialization
    void Start () {
        
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("MainCharacter").GetComponent<PlayerScript>().hunting && walking == false)
        {
            switch (transform.name)
            {
                case "lion1":
                    transform.position = new Vector2(transform.position.x + 5, transform.position.y);
                    GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case "lion2":
                    transform.position = new Vector2(transform.position.x + 5, transform.position.y);
                    GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case "lion3":
                    transform.position = new Vector2(transform.position.x + 5, transform.position.y);
                    GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case "lion4":
                    transform.position = new Vector2(transform.position.x - 5, transform.position.y);
                    break;
                case "lion5":
                    transform.position = new Vector2(transform.position.x - 5, transform.position.y);
                    break;
                case "lion6":
                    transform.position = new Vector2(transform.position.x - 5, transform.position.y);
                    break;
                

            }
            InvokeRepeating("walk", 0, 1.0f);
            walking = true;
        }
        
    }

    void walk()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        int ranx = Random.Range(-100, 100);
        int rany = Random.Range(-100, 100);
        Vector2 dir = new Vector2(ranx * speed, rany * speed);
        rigidbody.AddForce(dir);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "weapon")
        {
            if (collision.GetComponent<HuntingWeapon>().flying == true)
            {
                collision.GetComponent<HuntingWeapon>().killed++;
                Destroy(this.gameObject);
            }
            
        }
    }
}
