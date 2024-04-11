using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;

    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManger.Instance.OnscoreChange(this.score, maxScore);
        //NoteManager.Instance.Create();

        StartCoroutine(TimerCoroutine());
    }
    
    IEnumerator TimerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManger.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;
        }
        Debug.Log("Game Over.............");
    }

    public void CalculateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
        }
        else
        {
            score--;
        }

        UIManger.Instance.OnscoreChange(this.score, maxScore);
    }
}
