using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private int score;
   

    // Update is called once per frame
    public void scoreIncrement()
    {
        score++;
        scoreUpdate();
    }
    private void scoreUpdate()
    {
        scoreText.text = "Brains : "+score;   
    }
}
