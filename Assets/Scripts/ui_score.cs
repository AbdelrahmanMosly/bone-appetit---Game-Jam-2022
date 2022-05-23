using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_score : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    
    [SerializeField]
    private GameObject youNeverDie;
    [SerializeField]
    private ObstacleThrower obstacleThrower;

    [SerializeField]
    private GameObject player;

    private int score;


    public void enable_screen()
    {
        youNeverDie.active = true;
    }

    public void disable_screen()
    {
        youNeverDie.active = false;
    }


    // Update is called once per frame
    public void scoreIncrement()
    {
        score++;
        scoreUpdate(); 
        if(obstacleThrower.getProjectileVelocity() <=20.0f)
             obstacleThrower.updateProjectileSpeed(score);
    }
    public int getScore()
    {
        return score;
    }
    private void scoreUpdate()
    {
        scoreText.text = "Brains : "+score;   
    }

    public IEnumerator reply()
    {
        enable_screen();
        player.transform.position =new Vector3(transform.position.x,transform.position.y,0);
        yield return new WaitForSeconds(1);
        disable_screen();
    }

}
