using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerControlInput input;
    public Vector2 Dircation;

    [Header("Basic_Attributes")]
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private SpriteRenderer sptRander;
    private PhysicsCheck phyCheck;

    private void Awake()
    {
        input = new PlayerControlInput();
        input.Player.Jump.started += Jump;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sptRander = GetComponent<SpriteRenderer>();
        phyCheck = GetComponent<PhysicsCheck>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Dircation = input.Player.Move.ReadValue<Vector2>();
        sptRander.flipX = Dircation.x > 0 ? false : (Dircation.x < 0) ? true : sptRander.flipX;
        rb.velocity = new Vector2(speed * Dircation.x * Time.deltaTime, rb.velocity.y);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (!phyCheck.CheckGround()) return;

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
