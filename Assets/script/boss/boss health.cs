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
        Debug.Log("Le boss a pris " + damage + " dégâts");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Le boss est mort !");
        Destroy(gameObject);
    }
}
