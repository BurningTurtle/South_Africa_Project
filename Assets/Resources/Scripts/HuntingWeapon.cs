using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HuntingWeapon : MonoBehaviour {

    [SerializeField] private Text text;
    public bool given, flying, initiated;
    public int killed;
    public bool keyboard;

    // Use this for initialization
    void Start () {
        text.CrossFadeAlpha(0f, 0f, false);
        flying = false;
        given = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("MainCharacter").GetComponent<PlayerScript>().hunting == true && !flying && given)
        {
            GameObject player = GameObject.Find("MainCharacter");
            transform.position = new Vector2(player.transform.position.x + 0.81f, player.transform.position.y + 0.49f);
            //transform.localPosition = new Vector2(0.81f, 0.49f);
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }

        if (keyboard)
        {
            rotateToMouse();
            if(Input.GetMouseButtonDown(0))
            {
                if (given)
                {
                    StartCoroutine(fly());
                }

            }
        }
        else
        {
            rotateToJoystick();
            if (Input.GetKeyDown("joystick button 5"))
            {
                if (given)
                {
                    StartCoroutine(fly());
                }
            }

        }
        
        if(killed < 6 && killed >= 1 && GameObject.Find("MainCharacter").GetComponent<PlayerScript>().hunting)
        {
            text.fontSize = 80;
            text.CrossFadeAlpha(1f, 2f, false);
            text.text = (6 - killed) + " remaining";
        }
        if(killed == 6)
        {
            text.text = "success";
            text.CrossFadeAlpha(0f, 2f, false);
            Destroy(this.gameObject);
        }
    }

    IEnumerator fly()
    {
        if(keyboard)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            flying = true;
            GetComponent<Rigidbody2D>().AddForce(dir * 200);
            yield return new WaitForSeconds(1f);
            flying = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else
        {
            float horizontal = Input.GetAxisRaw("HorizontalRight");
            float vertical = Input.GetAxisRaw("VerticalRight");
            float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            Vector3 dir = Quaternion.AngleAxis(angle-90, Vector3.forward) * Vector3.right;
            flying = true;
            GetComponent<Rigidbody2D>().AddForce(dir * 200);
            yield return new WaitForSeconds(1f);
            flying = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "MainCharacter")
        {
            if (!initiated)
            {
                GameObject.Find("MainCharacter").GetComponent<PlayerScript>().hunting = true;
                text.text = "The hunt is on";
                StartCoroutine(huntIsOn());
                given = true;
                initiated = true;
            }
            
        }
    }

    IEnumerator huntIsOn()
    {
        text.CrossFadeAlpha(1f, 2f, false);
        yield return new WaitForSeconds(2f);
        text.CrossFadeAlpha(0f, 2f, false);
    }

    private void rotateToMouse()
    {
        if(given == true && !flying)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }

    }

    private void rotateToJoystick()
    {
        if (given == true && !flying)
        {
            float horizontal = Input.GetAxisRaw("HorizontalRight");
            float vertical = Input.GetAxisRaw("VerticalRight");
            float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
        }
    }
       
}
