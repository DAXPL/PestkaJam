using NUnit.Framework.Internal;
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
    [SerializeField] private float hitDist = 1;

    Vector2 capsuleSize = Vector2.zero;
    CapsuleCollider2D col;
    Rigidbody2D rb;
    bool alive = true;

    void Start()
    {
        col = GetComponent<CapsuleCollider2D>();
        capsuleSize = col.size;
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
        if(context.performed && IsGrounded())
        {
            rb.AddForce(jumpAcceleration*Vector2.up, ForceMode2D.Impulse);
        }
    }
    private bool IsGrounded()
    {
        List<ContactPoint2D> cpp = new List<ContactPoint2D>();
        col.GetContacts(cpp);
        foreach (ContactPoint2D cpD in cpp)
        {
            int layer = cpD.collider.gameObject.layer;
            if (LayerMask.NameToLayer("Ground")== layer || LayerMask.NameToLayer("Wall") == layer)
            {
                
                float angle = AtanAngle(cpD.point, transform.position); 
                if (angle < -2.1f && angle > -2.3f) 
                {
                    //Debug.DrawLine(cpD.point, cpD.point + (Vector2.up * 0.5f), Color.red, 3);
                    //Debug.DrawLine(transform.position, transform.position + (Vector3.up * 0.5f), Color.yellow, 3);
                    //Debug.Log(angle);
                    return true;
                }
                
            }            
        }
        return false;
    }
    private float AtanAngle(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x);
    }

    public void KillPlayer(bool stop = false)
    {
        alive = false;
        if (stop)
        {
            rb.velocity= Vector2.zero;
            rb.simulated= false;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

}
