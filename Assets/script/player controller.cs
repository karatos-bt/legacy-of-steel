using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 checkpointPosition;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        checkpointPosition = startPosition;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
    }

    public void Respawn()
    {
        transform.position = checkpointPosition;
        GetComponent<PlayerHealth>().RestoreFullHealth();  // Correct aussi
        Debug.Log("Respawn au checkpoint");
    }
    public void EnableControls(bool state)
    {
        GetComponent<DeplacementCapsule>().enabled = state;
        GetComponent<PlayerAttack>().enabled = state;
        GetComponent<DoubleJump2D>().enabled = state;
        GetComponent<PlayerBlock>().enabled = state;
    }
}
