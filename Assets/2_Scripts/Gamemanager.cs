using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;

    [SerializeField] private int maxScore;
    private int score;

    private void Awake()
    {
        Instance = this;
        UIManger.Instance.OnscoreChange(score, maxScore);
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
        }else
        {
            score--;
        }

        UIManger.Instance.OnscoreChange(score, maxScore);

    }
}
