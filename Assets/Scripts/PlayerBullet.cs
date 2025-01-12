using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 1; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBot enemy = collision.gameObject.GetComponent<EnemyBot>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); 
                Debug.Log("Enemy hit!");
            }
        }

        Destroy(gameObject); 
    }
}