using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupCreateScore = 10;
    private int score;
    private int nextNoteGroupUnlockCnt;
    private bool isGameClear = false;
    private bool isGameOver = false;

    [SerializeField] private float maxTime = 30;
    [HideInInspector] public static float myTime;
    [HideInInspector] public static float minTime;

    public bool IsGameClear()
    {
        return isGameClear;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameDone
    {
        get
        {
            if (isGameClear || isGameOver)
            {
                minTime = PlayerPrefs.GetFloat("minTime", 1000f);
                if (minTime >= myTime)
                {
                    minTime = myTime;
                    PlayerPrefs.SetFloat("minTime", minTime);
                }

                SceneManager.LoadScene("Clear");
                return true;
            }
            else
                return false;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            myTime = currentTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }

        isGameOver = true;
        SceneManager.LoadScene("Over");
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
                isGameClear = true;
            }

        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }

    public void Restart()
    {
        Debug.Log("Game Restart!................");
        SceneManager.LoadScene(0);
    }
}