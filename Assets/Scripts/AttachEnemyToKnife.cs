using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachEnemyToKnife : MonoBehaviour
{
    [SerializeField]
    private string enemyTag;
    [SerializeField]
    private GameObject initialEnemyParent;
    private int enemyCaughtCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(enemyTag) 
            && collision.gameObject.transform.parent== initialEnemyParent)
        {
            removeRigidBody2DCompoenent(collision);
            adjustPosition(collision);
            adjustAngle(collision);
            adjustParent(collision);
        }
    }
    private void removeRigidBody2DCompoenent(Collider2D collision)
    {
        Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
    }
    private void adjustParent(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(transform.parent, false);
    }
    private void adjustAngle(Collider2D collision)
    {
        collision.gameObject.transform.eulerAngles = new Vector3(0, 0, -90);
    }
  
    private void adjustPosition(Collider2D collision)
    {
        collision.gameObject.transform.position = new Vector3(0, (enemyCaughtCount++)*0.5f, 0);
    }
}
