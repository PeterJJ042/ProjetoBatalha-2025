using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float dano = 20f; 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        // Certifique-se de que o objeto colidido tem a tag "Enemy"
        if (collision.gameObject.CompareTag("inimigo"))
        {
            VidaNPC enemyHealth = collision.gameObject.GetComponent<VidaNPC>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20f); // Causa 20 de dano
            }
            Destroy(gameObject); // Destrói o projétil ao colidir
        }
        */
    }

    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.CompareTag("Enemy"))
        {
            VidaNPC enemyHealth = colisao.gameObject.GetComponent<VidaNPC>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(dano); // Causa dano
            }
            Destroy(gameObject); // Destrói o projétil ao colidir
        }
    }
}
