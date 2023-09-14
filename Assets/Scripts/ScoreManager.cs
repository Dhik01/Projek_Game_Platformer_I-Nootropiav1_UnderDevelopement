using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager InstanceScoreM;

    public int Score;
    [SerializeField] private TMP_Text ScoreDisplay;

    private void Awake()
    {
        if (!InstanceScoreM)
        {
            InstanceScoreM = this;
        }
    }

    private void OnGUI()
    {
        ScoreDisplay.text = Score.ToString();
    }

    public void ChangeScore(int amount)
    {
        Score += amount;
    }
}
