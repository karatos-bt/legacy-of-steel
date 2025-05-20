using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10; // D�g�ts inflig�s


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("D�g�ts inflig�s au joueur : " + damageAmount);

            }
        }
    }
}
