using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCarre : MonoBehaviour
{
    public float vitesse = 5f;  // Vitesse de déplacement
    private bool isFacingRight = true;

    void Update()
    {
        // Récupère les entrées clavier pour les mouvements gauche/droite
        float mouvementHorizontal = 0f;

        // Déplacement à gauche avec 'Q'
        if (Input.GetKey(KeyCode.K))    
        {
            mouvementHorizontal = -1f;  // Déplacer à gauche
            
        }
        // Déplacement à droite avec 'D'
        else if (Input.GetKey(KeyCode.L))
        {
            mouvementHorizontal = 1f;  // Déplacer à droite
            
        }

        // Déplacement de la capsule le long de l'axe X
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
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}