using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestionController : MonoBehaviour {

    [SerializeField] private Text question, answers, right, wrong;
    private bool answered = false;
    private int answer;

    // Use this for initialization
    void Start () {
        question.CrossFadeAlpha(0f, 0f, false);
        answers.CrossFadeAlpha(0f, 0f, false);
        right.CrossFadeAlpha(0f, 0f, false);
        wrong.CrossFadeAlpha(0f, 0f, false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name == "MainCharacter")
        {
            switch(this.transform.name)
            {
                case "geography1":
                    question.text = "Which South African neighbor country is bordered by the river Orange";
                    answers.text = "1 Namibia   2 Botswana   3 Mosambik   4 Simbabwe";
                    StartCoroutine(getAnswer("g1"));
                    break;
            }
        }
    }

    IEnumerator getAnswer(string i)
    {
        question.CrossFadeAlpha(1f, 2f, false);
        answers.CrossFadeAlpha(1f, 3f, false);
        while (answered == false)
        {
            if(Input.GetKeyDown("1"))
            {
                answered = true;
                answer = 1;
            }
            if (Input.GetKeyDown("2"))
            {
                answered = true;
                answer = 2;
            }
            if (Input.GetKeyDown("3"))
            {
                answered = true;
                answer = 3;
            }
            if (Input.GetKeyDown("4"))
            {
                answered = true;
                answer = 4;
            }
            yield return null;
        }
        question.CrossFadeAlpha(0f, 1f, false);
        answers.CrossFadeAlpha(0f, 1f, false);
        switch (i)
        {
            case "g1":
                if (answer == 1)
                {
                    StartCoroutine(rightAnswer());
                }
                else
                {
                    StartCoroutine(wrongAnswer());
                }
                break;
        }
        answered = false;
    }

    IEnumerator rightAnswer()
    {
        right.CrossFadeAlpha(1f, 2f, false);
        GameObject.Find("Fountain").GetComponent<Fountain>().karma += 5; //CHANGE!
        yield return new WaitForSeconds(2f);
        right.CrossFadeAlpha(0f, 2f, false);
    }

    IEnumerator wrongAnswer()
    {
        wrong.CrossFadeAlpha(1f, 2f, false);
        GameObject.Find("Fountain").GetComponent<Fountain>().karma -= 1;
        yield return new WaitForSeconds(2f);
        wrong.CrossFadeAlpha(0f, 2f, false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
