using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestionController : MonoBehaviour {

    [SerializeField] private Text question, answers, right, wrong;
    private bool answered = false;
    private int answer;
    bool geo1ans, geo2ans, geo3ans, geo4ans;
    bool ff1ans, ff2ans, ff3ans, ff4ans;
    string currentQuestion;

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
                    if (!geo1ans)
                    {
                        currentQuestion = "geography1";
                        question.text = "Which South African neighbor country is bordered by the river Orange";
                        answers.text = "1 Namibia   2 Botswana   3 Mosambik   4 Simbabwe";
                        StartCoroutine(getAnswer(1));
                    }
                    break;
                case "geography2":
                    if (!geo2ans)
                    {
                        currentQuestion = "geography2";
                        question.text = "Which ocean borders South Africa";
                        answers.text = "1 Pacific   2 Barents Sea   3 Atlantic   4 Artic";
                        StartCoroutine(getAnswer(3));
                    }
                    break;
                case "geography3":
                    if (!geo3ans)
                    {
                        currentQuestion = "geography3";
                        question.text = "Which of the following is the longest river in South Africa";
                        answers.text = "1 Orange River   2 Red River   3 Blue River   4 None of them";
                        StartCoroutine(getAnswer(1));
                    }
                    break;
                case "geography4":
                    if (!geo4ans)
                    {
                        currentQuestion = "geography4";
                        question.text = "What is the southernmost point of the African continent";
                        answers.text = "1 Cape Branco   2 Cape of Good Hope   3 Cape Corrientes   4 Cape Agulhas";
                        StartCoroutine(getAnswer(4));
                    }
                    break;

                case "ff1":
                    if (!ff1ans)
                    {
                        currentQuestion = "ff1";
                        question.text = "What can you admire in the Auckland Nature Reserve at Hogsback";
                        answers.text = "1 Many many different plants   2 The world's largest bloom   3 Penguins   4 Original South African forest";
                        StartCoroutine(getAnswer(4));
                    }
                    break;
                case "ff2":
                    if (!ff2ans)
                    {
                        currentQuestion = "ff2";
                        question.text = "How is the vegetation in the north-west of South Africa";
                        answers.text = "1 Many lions   2 Sparse   3 Species-rich   4 Only baobabs";
                        StartCoroutine(getAnswer(3));
                    }
                    break;
                case "ff3":
                    if (!ff3ans)
                    {
                        currentQuestion = "ff3";
                        question.text = "What type of rhinoceros are there in South Africa";
                        answers.text = "1 White rhino   2 One-horned rhino   3 Java rhino   4 Great Matiko rhino";
                        StartCoroutine(getAnswer(1));
                    }
                    break;
                case "ff4":
                    if (!ff4ans)
                    {
                        currentQuestion = "ff4";
                        question.text = "Why are many species extinct in South Africa";
                        answers.text = "1 Dryness   2 Too much rainfall   3 Insertion of European species   4 Buffaloes eat everything";
                        StartCoroutine(getAnswer(3));
                    }
                    break;
            }   
        }
    }

    IEnumerator getAnswer(int rightAnswerInt)
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
        if (answer == rightAnswerInt)
        {
            StartCoroutine(rightAnswer());
            switch(currentQuestion)
            {
                case "geography1":
                    geo1ans = true;
                    break;
                case "geography2":
                    geo2ans = true;
                    break;
                case "geography3":
                    geo3ans = true;
                    break;
                case "geography4":
                    geo4ans = true;
                    break;

                case "ff1":
                    ff1ans = true;
                    break;
                case "ff2":
                    ff2ans = true;
                    break;
                case "ff3":
                    ff3ans = true;
                    break;
                case "ff4":
                    ff4ans = true;
                    break;
            }
        }
        else
        {
            StartCoroutine(wrongAnswer());
        }
        answered = false;
    }

    IEnumerator rightAnswer()
    {
        right.CrossFadeAlpha(1f, 2f, false);
        GameObject.Find("Fountain").GetComponent<Fountain>().karma += 1;
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
