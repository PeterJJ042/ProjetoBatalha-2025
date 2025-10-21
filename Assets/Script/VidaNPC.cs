using UnityEngine;
using UnityEngine.UI;

public class VidaNPC : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    private float currentHealth;
    public GameObject explosionEffect;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

        GameObject effect = Instantiate(explosionEffect, this.transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }
}
