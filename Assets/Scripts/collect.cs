using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    private ui_score uiScore;
    private void Awake()
    {
        uiScore = Camera.main.GetComponent<ui_score>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            uiScore.scoreIncrement();
            Camera.main.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}
