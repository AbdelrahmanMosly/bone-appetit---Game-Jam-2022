using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachEnemyToKnife : MonoBehaviour
{
    [SerializeField]
    private string enemyTag;
    [SerializeField]
    private string parentTag;
    [SerializeField]
    private GameObject brain;
    [SerializeField]
    private ObstacleThrower thrower;

    private int enemyCaughtCount;
    
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag(enemyTag) 
            && collision.gameObject.transform.parent.CompareTag(parentTag))
        {
            Instantiate(brain);
            killEnemy(collision);
            adjustPosition(collision);
            adjustParent(collision);
        }
    }
    private void killEnemy(Collider collision)
    {
        Destroy(collision.gameObject.GetComponent<Rigidbody>());
        Destroy(collision.gameObject.GetComponent<EnemyMovement>());
        Destroy(collision.gameObject.transform.GetChild(2).GetComponent<ObstacleThrower>());
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
