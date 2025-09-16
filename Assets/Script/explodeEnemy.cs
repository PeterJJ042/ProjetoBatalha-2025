using UnityEngine;

public class explodeEnemy : MonoBehaviour
{
    public GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {

        // Verifica se colidiu com o inimigo
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {

            GameObject effect = Instantiate(explosionEffect, collision.transform.position, Quaternion.identity);
            Destroy(effect, 1f);

            // Destroi o inimigo
            Destroy(collision.gameObject);

            // Destroi o projétil também para não ficar voando
            Destroy(gameObject);
        }
    }
}
