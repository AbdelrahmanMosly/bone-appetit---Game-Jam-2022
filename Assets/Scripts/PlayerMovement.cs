using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            rigidbody2D.velocity= Vector2.up*jumpVelocity;
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,
                                                            0f, Vector2.down, 1f, platformLayerMask);
        return raycastHit2D.collider != null;
    }
}
