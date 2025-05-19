
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public Slider healthBar; // R�f�rence � la barre de vie

    private PlayerBlock playerBlock; // R�f�rence au blocage

    void Start()
    {
        currentHealth = maxHealth;

        playerBlock = GetComponent<PlayerBlock>(); // R�cup�re le script de blocage

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        // V�rifie si le joueur bloque
        if (playerBlock != null && playerBlock.isBlocking)
        {
            Debug.Log(" Attaque bloqu�e !");
            return; // Ne prend pas de d�g�ts
        }

        // Applique les d�g�ts normalement
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(" Le joueur a pris " + damage + " d�g�ts.");

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(" Le joueur est mort !");
        // Animation ou redirection � pr�voir ici
    }
}
