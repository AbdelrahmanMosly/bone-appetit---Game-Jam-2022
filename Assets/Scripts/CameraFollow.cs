using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private AudioSource player_audio;
    [SerializeField] private Vector3 Offset = new Vector3(10, 10, 0);
    [SerializeField] private Texture2D texture_curser;
    public float ratio = 0.3f;


    Vector3 previous_loc;


    private void Start()
    {
        previous_loc = target.position;
        Time.timeScale = 1;
        Cursor.SetCursor(texture_curser, Vector2.zero, CursorMode.Auto);
    }
    bool isplayed = false;
    void playsound()
    {
        if (isplayed == false)
        {
            player_audio.Play();
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            isplayed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (target.position.y > transform.position.y - 3)
        {
            Vector3 interpolatedPosition = Vector3.Lerp(previous_loc, target.position, ratio);
            previous_loc = interpolatedPosition;

            transform.position = interpolatedPosition + Offset;
        }
        else if(target.position.y < transform.position.y - 15)
        {
            playsound();
            StartCoroutine(Camera.main.GetComponent<ui_score>().reply());
        
        }
        
    }
}
