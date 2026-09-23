using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private float attackCooldown = 1f;

    private float nextAttackTime;

    private Transform player;
    private bool playerDetected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            player = null;
        }
    }

    private void Update()
    {
        if (!playerDetected || player == null)
            return;

        float distance =
            Vector2.Distance(
                transform.position,
                player.position
            );

        if (distance > attackDistance)
        {
            MoveTowardPlayer();
        }
        else
        {
            Attack();
        }
    }

    private void MoveTowardPlayer()
    {
        Vector2 direction =
            (player.position - transform.position)
            .normalized;

        transform.position +=
            (Vector3)(direction *
            moveSpeed *
            Time.deltaTime);

        if (direction.x != 0)
        {
            transform.localScale =
                new Vector3(
                    Mathf.Sign(direction.x),
                    1,
                    1
                );
        }
    }
    private void Attack()
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime =
            Time.time + attackCooldown;

        if (player.TryGetComponent<PlayerHealth>(
            out PlayerHealth health))
        {
            health.TakeDamage(damage);
        }
    }
}