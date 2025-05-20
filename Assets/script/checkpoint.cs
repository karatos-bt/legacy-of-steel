using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Quelque chose est entré : " + other.name); // Log pour débogage

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.SetRespawnPoint(transform.position);  // Correct
                playerHealth.RestoreFullHealth();                  // Correct
                Debug.Log("Checkpoint atteint !");
            }
        }
    }
}
