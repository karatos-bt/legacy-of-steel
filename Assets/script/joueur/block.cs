using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public bool isBlocking { get; private set; } = false;
    public KeyCode blockKey = KeyCode.LeftShift;

    private bool previousBlockState = false;

    void Update()
    {
        isBlocking = Input.GetKey(blockKey);

        // Vérifie si l'état de blocage a changé
        if (isBlocking != previousBlockState)
        {
            EnableControls(!isBlocking); // Désactive les contrôles quand on bloque
            previousBlockState = isBlocking;
        }

        Debug.Log("isBlocking = " + isBlocking);
    }

    public void EnableControls(bool state)
    {
        GetComponent<DeplacementCapsule>().enabled = state;
        GetComponent<PlayerAttack>().enabled = state;
        GetComponent<DoubleJump2D>().enabled = state;
    }
}
