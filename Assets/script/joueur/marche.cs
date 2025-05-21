using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCapsule : MonoBehaviour
{
    public float vitesse = 5f;  // Vitesse de d�placement

    void Update()
    {
        // R�cup�re les entr�es clavier pour les mouvements gauche/droite
        float mouvementHorizontal = 0f;

        // D�placement � gauche avec 'Q'
        if (Input.GetKey(KeyCode.A))
        {
            mouvementHorizontal = -1f;  // D�placer � gauche
        }
        // D�placement � droite avec 'D'
        else if (Input.GetKey(KeyCode.D))
        {
            mouvementHorizontal = 1f;  // D�placer � droite
        }

        // D�placement de la capsule le long de l'axe X
        transform.position += new Vector3(mouvementHorizontal, 0f, 0f) * vitesse * Time.deltaTime;
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        // Met � jour la position de l'attackPoint
        attackPoint.localPosition = isFacingRight ? attackOffsetRight : attackOffsetLeft;
    }
    public Transform attackPoint;
    public Vector2 attackOffsetRight = new Vector2(1f, 0f);
    public Vector2 attackOffsetLeft = new Vector2(-1f, 0f);
    private bool isFacingRight = true;


    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}