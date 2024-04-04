using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    public static UIManger Instance;

    [SerializeField] private Image scoreImg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    private void Awake()
    {
        Instance = this;
    }

    public void OnscoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore}/{maxScore}";
        scoreImg.fillAmount = (float)currentScore / maxScore;

    }

}
