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
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            player.TakeDamage(10);
        }
        if (collision.gameObject.name != "Gun")
        {
            Destroy(gameObject);
        }
    }
}