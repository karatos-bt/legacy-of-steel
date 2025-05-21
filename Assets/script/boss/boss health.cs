using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("🧠 Boss a pris " + damage + " dégâts. Santé restante : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("💀 Le boss est mort !");
        Destroy(gameObject);
    }
}
