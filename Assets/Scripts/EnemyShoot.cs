using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;

    private Transform player;
    private float nextFireTime;

    private void Update()
    {
        if (player == null)
            return;

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime =
                Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Vector2 direction =
            (player.position - firePoint.position)
            .normalized;

        GameObject bullet = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        Projectile projectile =
            bullet.GetComponent<Projectile>();

        projectile.SetDirection(direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}