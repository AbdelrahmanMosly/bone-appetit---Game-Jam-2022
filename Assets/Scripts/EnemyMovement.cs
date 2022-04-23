using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private GroundCheck GC1;
    [SerializeField] private GroundCheck GC2;
    [SerializeField] private float moveVelocity = 20f;
    [SerializeField] private GameObject ObstacleThrower;
    [SerializeField] private PlayerInRange playerInRange;


    private int direction=-1;
    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }
    private void move()
    {
        playerDetectedMove();
        normalMove();
    }
    private void playerDetectedMove()
    {
        if (playerInRange.playerInRange)
        {
            direction = (playerInRange.getPlayerTransform().position.x - transform.position.x) > 0 ? 1 : -1;
            ObstacleThrower.transform.localPosition = new Vector3(direction, 0, 0);
        }
    }
    private void normalMove()
    {
        if (goingToFall())
        {
            direction *= -1;
            transform.position = new Vector3(transform.position.x + direction * 0.1f, transform.position.y, transform.position.z);
        }
        else
        {
            rigidbody.velocity = new Vector2(direction * moveVelocity, rigidbody.velocity.y);
        }
    }
    private bool goingToFall()
    {
        return !(GC1.Grounded && GC2.Grounded);
    }
}
