using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("movement")]
    [SerializeField] private Vector2 rawMovementInput = Vector2.zero;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float jumpAcceleration = 5f;
    [SerializeField] private ParticleSystem iskryXD;
    [SerializeField] private ParticleSystem deathParticles;
    [Header("Audio")]
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip crash;
    private AudioSource ass;

    Vector2 capsuleSize = Vector2.zero;
    CapsuleCollider2D col;
    Rigidbody2D rb;
    bool alive = true;
    bool canDoFlip = false;

    void Start()
    {
        col = GetComponent<CapsuleCollider2D>();
        capsuleSize = col.size;
        rb = GetComponent<Rigidbody2D>();
        iskryXD.Play();
        ass = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        PlayerMove();
    }
    private void FixedUpdate()
    {     
        //tutaj powinienem sprawdzaæ czy iskry istniej¹
        iskryXD.enableEmission = IsGrounded() && (rb.velocity.magnitude > maxSpeed / 4);
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
        if(rawMovementInput.x<0) sprite.flipX= true;
        if (rawMovementInput.x > 0) sprite.flipX = false;
    }
    public void HandlePlayerJumpInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(IsGrounded())
            {
                rb.AddForce(jumpAcceleration * Vector2.up, ForceMode2D.Impulse);
                rb.AddTorque(jumpAcceleration * Random.Range(0.01f, 0.1f) * RandomSign(), ForceMode2D.Impulse);
                canDoFlip = true;
                if (ass) ass.PlayOneShot(jump);
            }
            else if (canDoFlip)
            {
                rb.AddForce(jumpAcceleration * Vector2.up*0.75f, ForceMode2D.Impulse);
                rb.AddTorque(jumpAcceleration * Random.Range(0.1f, 0.3f) * RandomSign(), ForceMode2D.Impulse);
                canDoFlip = false;
                if (ass) ass.PlayOneShot(jump);
            }
            
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
                if (angle < -0.1f && angle > -2.6f) 
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
    private int RandomSign()
    {
        return (Random.Range(0,2)==1) ? -1 : 1;
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
            LockPlayerMovement(true);
        }
        deathParticles.Play();
        if (ass) ass.PlayOneShot(crash);
    }
    public void LockPlayerMovement(bool state)
    {
        if (state)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
            
        rb.simulated = !state;
                 
    }

}
