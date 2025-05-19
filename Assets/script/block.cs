using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public bool isBlocking { get; private set; } = false;
    public KeyCode blockKey = KeyCode.LeftShift;

   
    void Update()
    {
        isBlocking = Input.GetKey(blockKey);
        Debug.Log("isBlocking = " + isBlocking);
    }
}
