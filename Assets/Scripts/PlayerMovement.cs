using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveVelocity = 20f;
    [SerializeField] private float jumpVelocity = 50f;
    [SerializeField] private LayerMask platformLayerMask;


    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D=transform.GetComponent<Rigidbody2D>();
        boxCollider2D=transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        JumpCheck();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCheck();
    }
    private void JumpCheck()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }
    }
    private void MoveCheck()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-moveVelocity, rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) { 
            rigidbody2D.velocity=new Vector2(moveVelocity , rigidbody2D.velocity.y);
        }
        else //stop it
        {
            rigidbody2D.velocity = new Vector2 (0 , rigidbody2D.velocity.y);
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,
                                                            0f, Vector2.down, 1f, platformLayerMask);
        return raycastHit2D.collider != null;
    }
}
