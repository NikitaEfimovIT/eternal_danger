using UnityEngine;

public class EnemyBot : MonoBehaviour
{
    public Transform player; 
    public GameObject bulletPrefab; 
    public Transform gunPoint; 
    public float detectionRange = 15f;
    public float shootingInterval = 2f;
    public float bulletSpeed = 10f; 
    public int maxHealth = 3; 

    private int currentHealth;
    private float shootingTimer;

    private void Start()
    {
        currentHealth = maxHealth; 
    }

    private void Update()
    {
        if (IsPlayerVisible())
        {
            LookAtPlayer();
            shootingTimer -= Time.deltaTime;
            if (shootingTimer <= 0f)
            {
                Shoot();
                shootingTimer = shootingInterval;
            }
        }
    }

    private bool IsPlayerVisible()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > detectionRange)
            return false;

        int layerMask = ~LayerMask.GetMask("IgnoreRaycast");
        if (Physics.Raycast(gunPoint.position, directionToPlayer, out RaycastHit hit, detectionRange, layerMask))
        {
            return hit.collider.CompareTag("Player");
        }
        return false;
    }

    private void LookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = gunPoint.forward * bulletSpeed;
        }
        Destroy(bullet, 5f);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy took damage! Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy destroyed!");
        Destroy(gameObject); 
    }
}
