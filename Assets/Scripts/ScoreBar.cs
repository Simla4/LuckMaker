using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text scoreText;
    
    public void setMinScore()
    {
        slider.minValue = 0;
        slider.value = 0;
    }

    public void setScore(int score)
    {
        slider.value = score;
        
    }
    public void setScoreText (int score)
    {
        scoreText.text = score.ToString();
    }
    
}
