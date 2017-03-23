using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{

    private Animator animator;
    public int karma;
    [HideInInspector]
    public int water = 0;
    public UIController uic;
    [Header("Time in s")]
    [SerializeField]
    private float period;
    private int elapsedSinceAction;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        InvokeRepeating("KarmaAction", 0, period);
        InvokeRepeating("timeUntilAction", 0, 1);
    }

    void timeUntilAction()
    {
        if (elapsedSinceAction > period)
            elapsedSinceAction = 1;
        elapsedSinceAction += 1;
    }

    void KarmaAction()
    {
        int random = Random.Range(1, 10);
        switch (karma)
        {
            case -5:
                if (random < 2)
                {
                    water += 1;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case -4:
                if (random < 3)
                {
                    water += 1;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case -3:
                if (random < 4)
                {
                    water += 1;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case -2:
                if (random < 5)
                {
                    water += 1;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case -1:
                if (random < 6)
                {
                    water += 1;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case 1:
                if (random < 7)
                {
                    water += 1;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case 2:
                if (random < 8)
                {
                    water += 2;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case 3:
                if (random < 9)
                {
                    water += 3;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case 4:
                if (random < 10)
                {
                    water += 4;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;

            case 5:
                if (random < 11)
                {
                    water += 5;
                    uic.fadePositive();
                }
                else
                {
                    water -= 1;
                    uic.fadeNegative();
                }
                break;
        }

    }

    public void setState(int state)
    {
        animator.SetInteger("state", state);
    }

    // Update is called once per frame
    void Update()
    {
        setState((water - (water % 10)) / 10);
        Debug.Log("Water: " + water);
        Debug.Log("Karma: " + karma);
    }



}
