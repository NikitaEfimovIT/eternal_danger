using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f; 

    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}
