using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private GroundCheck GC1;
    [SerializeField] private GroundCheck GC2;
    [SerializeField] private float moveVelocity = 20f;

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
        if (goingToFall())
        {
            direction *= -1;
            transform.eulerAngles=new Vector3(0, 180*direction, 0);
            transform.position = new Vector3(transform.position.x+direction*0.1f, transform.position.y, transform.position.z);
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
