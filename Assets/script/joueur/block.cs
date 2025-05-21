using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public bool isBlocking { get; private set; } = false;
    public KeyCode blockKey = KeyCode.LeftShift;

    private bool previousBlockState = false;

    void Update()
    {
        isBlocking = Input.GetKey(blockKey);

        // V�rifie si l'�tat de blocage a chang�
        if (isBlocking != previousBlockState)
        {
            EnableControls(!isBlocking); // D�sactive les contr�les quand on bloque
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
