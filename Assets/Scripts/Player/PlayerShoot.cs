using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            direction.y += 1;

        if (Input.GetKey(KeyCode.S))
            direction.y -= 1;

        if (Input.GetKey(KeyCode.D))
            direction.x += 1;

        if (Input.GetKey(KeyCode.A))
            direction.x -= 1;

        // Si aucune direction verticale/horizontale
        if (direction == Vector2.zero)
        {
            direction = transform.localScale.x > 0
                ? Vector2.right
                : Vector2.left;
        }

        direction.Normalize();

        GameObject bullet = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        Projectile projectile =
            bullet.GetComponent<Projectile>();

        projectile.SetDirection(direction);
    }
}