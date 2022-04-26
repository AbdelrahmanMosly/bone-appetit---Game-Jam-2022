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
    [SerializeField] private MovementManager MM;


    private Vector3 Player_velocity = Vector3.zero;
    private Rigidbody rigidbody;
    private float horiz, vert;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MM = gameObject.GetComponent<MovementManager>();

    }

    void Update()
    {
        horiz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        Player_velocity = new Vector2(horiz, vert);
        animationFix();
        JumpCheck();
       
    }
    

    void animationFix()
    {
        if (horiz > 0)
        {
            anim.SetBool("Run", true);
            PlayerMesh.transform.localScale = new Vector3(100, 100, 100);
        }
        else if (horiz < 0)
        {
            anim.SetBool("Run", true);
            PlayerMesh.transform.localScale = new Vector3(100, -100, 100);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MM.Move(rigidbody, Player_velocity, moveVelocity);
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


    private bool IsGrounded()
    {
         return GC.Grounded;
    }
}
