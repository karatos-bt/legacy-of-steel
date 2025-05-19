
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public Slider healthBar; // Référence à la barre de vie

    private PlayerBlock playerBlock; // Référence au blocage

    void Start()
    {
        currentHealth = maxHealth;

        playerBlock = GetComponent<PlayerBlock>(); // Récupère le script de blocage

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        // Vérifie si le joueur bloque
        if (playerBlock != null && playerBlock.isBlocking)
        {
            Debug.Log(" Attaque bloquée !");
            return; // Ne prend pas de dégâts
        }

        // Applique les dégâts normalement
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(" Le joueur a pris " + damage + " dégâts.");

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
        // Animation ou redirection à prévoir ici
    }
}
