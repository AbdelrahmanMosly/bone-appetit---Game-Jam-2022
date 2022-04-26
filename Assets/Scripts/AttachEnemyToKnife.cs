using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachEnemyToKnife : MonoBehaviour
{

    [SerializeField] private AudioSource player_audio1;
    [SerializeField] private AudioSource player_audio2;
    [SerializeField]
    private string enemyTag;
    [SerializeField]
    private string parentTag;
    [SerializeField]
    private GameObject brain;

    bool isplayed = false;

    private ObstacleThrower obstacleThrow;
    private int enemyCaughtCount;
    
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag(enemyTag)
            && collision.gameObject.transform.parent.CompareTag(parentTag))
        {
            GameObject brainInstantiation = Instantiate(brain, transform);
            brainInstantiation.transform.SetParent(null);
            brainInstantiation.transform.position += new Vector3(0, 0, -brainInstantiation.transform.position.z);
            killEnemy(collision);
            adjustPosition(collision);
            adjustParent(collision);

            player_audio1.Play();
            isplayed = true;
        }
        else
        {
            if (!isplayed)
            {
                player_audio2.Play();
                isplayed = true;
            }

        }
    }
    private void killEnemy(Collider collision)
    {
        Destroy(collision.gameObject.GetComponent<Rigidbody>());
        Destroy(collision.gameObject.GetComponent<EnemyMovement>());
        obstacleThrow = collision.gameObject.transform.GetChild(2).GetComponent<ObstacleThrower>();
        obstacleThrow.anim.speed=0;
        Destroy(obstacleThrow);

    }
    private void adjustParent(Collider collision)
    {
        collision.gameObject.transform.SetParent(transform, false);
    }
  
    private void adjustPosition(Collider collision)
    {
        collision.gameObject.transform.localPosition = new Vector3((enemyCaughtCount++) * 0.5f,0 , 0);
    }
}
