using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    public Rigidbody bulletPrefab; 
    public Transform firePoint;
    public float bulletForce = 30f; 
    public float fireRate = 0.2f; 

    private float nextFireTime = 0f; 

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && GameStateManager.Instance.onPause==false && GameStateManager.Instance.onInventory==false)
        {
            Shoot(); 
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Rigidbody rb = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }

        Debug.Log("Fired!");
    }
}
