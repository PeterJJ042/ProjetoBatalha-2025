using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float dano = 20f;

    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.CompareTag("Enemy"))
        {
            VidaNPC enemyHealth = colisao.gameObject.GetComponent<VidaNPC>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(dano); // Causa 20 de dano
            }
            Destroy(gameObject); // Destrói o projétil ao colidir
        }
    }
}
