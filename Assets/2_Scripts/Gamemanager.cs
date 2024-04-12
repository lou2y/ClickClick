using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;
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
        NoteManager.Instance.Create();

        gameClearObj.SetActive(false);
        gameOverObj.SetActive(false);

        StartCoroutine(TimerCoroutine());
    }

    public bool IsGameDone
    {
        get
        {
            if (gameClearObj.activeSelf || gameOverObj.activeSelf)
                    return true;
            else
                return false;
        }
    }

    IEnumerator TimerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManger.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if(IsGameDone)
            {
                yield break;
            }

        }
        Debug.Log("Game Over.............");

        //Game Over
        gameOverObj.SetActive(true);
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (maxScore <= score)
            {
                //Game Clear
                gameClearObj.SetActive(true);
            }
        }
        else
        {
            score--;
        }
        UIManger.Instance.OnscoreChange(this.score, maxScore);
    }

    public void Restart()
    {
        Debug.Log("Game Restart!...................");
        SceneManager.LoadScene(0);
    }
}
