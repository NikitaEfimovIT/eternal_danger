using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 1; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.name == "Gun")
        {
            EnemyBot enemy = collision.gameObject.GetComponent<EnemyBot>();
            if (enemy != null || collision.gameObject.name=="Gun")
            {
                enemy.TakeDamage(damage); 
                Debug.Log("Enemy hit!");
            }
        }
        if(collision.gameObject.name!="Player")
            Destroy(gameObject); 
    }
}