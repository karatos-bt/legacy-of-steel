using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10; // Dégâts infligés


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Dégâts infligés au joueur : " + damageAmount);

            }
        }
    }
}
