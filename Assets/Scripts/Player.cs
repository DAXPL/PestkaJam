using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 rawMovementInput = Vector2.zero;
    [SerializeField] private LayerMask groundMask;

    [Header("movement")]
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float jumpAcceleration = 5f;

    Vector2 capsuleSize = Vector2.zero;
    Rigidbody2D rb;
    void Start()
    {
        capsuleSize = GetComponent<CapsuleCollider2D>().size;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        float targetSpeed = rawMovementInput.x * maxSpeed;
        float speedDiff = targetSpeed - rb.velocity.x;
        rb.AddForce(speedDiff*acceleration*Vector2.right * Time.deltaTime, ForceMode2D.Force);
    }
    public void HandlePlayerMovementInput(InputAction.CallbackContext context)
    {
        rawMovementInput = context.ReadValue<Vector2>();
    }
    public void HandlePlayerJumpInput(InputAction.CallbackContext context)
    {
        if(IsGrounded() && context.performed)
        {
            rb.AddForce(jumpAcceleration*Vector2.up, ForceMode2D.Impulse);
        }
    }
    private bool IsGrounded()
    {

        return Physics2D.OverlapCapsule(transform.position, capsuleSize*1.01f, CapsuleDirection2D.Horizontal, 0, groundMask);
    }

}
