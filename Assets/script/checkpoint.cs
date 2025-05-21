using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Quelque chose est entré : " + other.name); 

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.SetRespawnPoint(transform.position);  
                playerHealth.RestoreFullHealth();                  
                Debug.Log("Checkpoint atteint !");
            }
        }
    }
}
