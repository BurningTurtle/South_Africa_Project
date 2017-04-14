using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HuntingWeapon : MonoBehaviour {

    [SerializeField] private Text text;
    bool given, flying, initiated;

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
        rotateToMouse();
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(fly());
        }
    }

    IEnumerator fly()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        GetComponent<Rigidbody2D>().AddForce(dir * 500);
        flying = true;
        yield return new WaitForSeconds(2f);
        flying = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
       
}
