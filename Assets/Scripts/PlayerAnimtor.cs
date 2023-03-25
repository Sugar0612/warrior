using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimtor : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    PhysicsCheck groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<PhysicsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimtorStateChange();
    }

    void AnimtorStateChange()
    {
        anim.SetFloat("speed_X", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("speed_Y", rb.velocity.y);
        anim.SetBool("whatIsGround", groundCheck.CheckGround());
    }
}
