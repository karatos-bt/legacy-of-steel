using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementCarre : MonoBehaviour
{
    public float vitesse = 5f;  // Vitesse de déplacement

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
    }
}