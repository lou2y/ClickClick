using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    private bool isGameClear = false;
    private bool isGameOver = false;
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


        StartCoroutine(TimerCoroutine());
    }

    public bool IsGameDone
    {
        get
        {
            if (isGameClear || isGameOver)
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
            SceneManager.LoadScene(3);

        //Game Over
        isGameOver=true;
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
                SceneManager.LoadScene("Clear");
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
        Debug.Log("Replay");
        SceneManager.LoadScene(0);
    }
}
