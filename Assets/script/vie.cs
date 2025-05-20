using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public Slider healthBar; // Référence à la barre de vie

    private PlayerBlock playerBlock; // Référence au blocage
    private Vector3 respawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        playerBlock = GetComponent<PlayerBlock>(); // Récupère le script de blocage

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        // Position initiale comme point de respawn
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            TakeDamage(-1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (playerBlock != null && playerBlock.isBlocking)
        {
            Debug.Log("Attaque bloquée !");
            return;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Le joueur a pris " + damage + " dégâts.");

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Le joueur est mort !");
        Respawn(); // Respawn instantané
    }

    private void Respawn()
    {
        transform.position = respawnPoint;  // Replacer le joueur au point de respawn
        RestoreFullHealth();                 // Rétablir sa santé
    }

    public void RestoreFullHealth()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
        Debug.Log("Santé restaurée !");
    }

    public void SetRespawnPoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("Nouveau point de respawn défini !");
    }
}
