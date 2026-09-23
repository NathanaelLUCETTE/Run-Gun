using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float speed =
            Mathf.Abs(rb.linearVelocity.x);

        bool grounded =
            Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );

        animator.SetFloat("Speed", speed);
        animator.SetBool("IsGrounded", grounded);
    }
}