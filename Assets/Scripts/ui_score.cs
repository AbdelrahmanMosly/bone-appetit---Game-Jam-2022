using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    
    [SerializeField]
    private GameObject gameoverscreen;

    private int score;


    public void enable_screen()
    {
        gameoverscreen.active = true;
    }

    public void disable_screen()
    {
        gameoverscreen.active = false;
    }


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

    public void reply()
    {
        Application.LoadLevel(0);
    }

}