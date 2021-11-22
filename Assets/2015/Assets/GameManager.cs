using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int playerScore = 0;
    public TMP_Text playerScoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreasePlayerScore(int score)
    {
        playerScore += score;
        UpdateScore();
    }

    void UpdateScore()
    {
        playerScoreText.SetText(""+playerScore);
    }
}
