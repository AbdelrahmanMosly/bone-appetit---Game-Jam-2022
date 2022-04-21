using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveVelocity = 20f;
    [SerializeField] private float jumpVelocity = 50f;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Animator anim;
    [SerializeField] private GroundCheck GC;


    private CapsuleCollider boxCollider;
    private Rigidbody rigidbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<CapsuleCollider>();
        //anim = GetComponent<Animator>();
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
            rigidbody.velocity = Vector2.up * jumpVelocity;
        }
    }
    private void MoveCheck()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-moveVelocity, rigidbody.velocity.y);
            transform.localScale = new Vector3(2, 2, -2);
            anim.SetBool("Run",true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) { 
            rigidbody.velocity=new Vector2(moveVelocity , rigidbody.velocity.y);
            transform.localScale = new Vector3(2, 2, 2);
            anim.SetBool("Run", true);
        }
        else //stop it
        {
            
            rigidbody.velocity = new Vector2 (0 , rigidbody.velocity.y);
            anim.SetBool("Run", false);
        }
    }
    private bool IsGrounded()
    {
         return GC.Grounded;
        //return (false);
    }
}
