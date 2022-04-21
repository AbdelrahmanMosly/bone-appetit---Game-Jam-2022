using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveVelocity = 20f;
    [SerializeField] private float jumpVelocity = 50f;
    [SerializeField] private Animator anim;
    [SerializeField] private GroundCheck GC;
    [SerializeField] private GameObject PlayerMesh;


    private Rigidbody rigidbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
            anim.Play("Jump", 0);
        }
        else
            anim.SetBool("Grounded", IsGrounded());
        

    }
    private void MoveCheck()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-moveVelocity, rigidbody.velocity.y);
            anim.SetBool("Run",true);
            PlayerMesh.transform.localScale = new Vector3(100, -100, 100);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) { 
            rigidbody.velocity=new Vector2(moveVelocity , rigidbody.velocity.y);
            anim.SetBool("Run", true);
            PlayerMesh.transform.localScale = new Vector3(100,100,100);
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
    }
}
