using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifetime = 5f; 

    private void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); 
    }
}