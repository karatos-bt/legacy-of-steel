using UnityEngine;

public class DoubleJump2D : MonoBehaviour
{
    public float forceDeSaut = 5f;        // Force du saut
    public LayerMask coucheSol;           // Layer mask pour détecter le sol
    private Rigidbody2D rb;               // Le Rigidbody2D du joueur
    private bool estAuSol;                // Vérifie si le joueur est au sol
    private int compteurDeSauts;          // Compteur de sauts effectués

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Récupère le Rigidbody2D du joueur
        compteurDeSauts = 0;               // Initialisation du compteur de sauts
    }

    void Update()
    {
        // Vérifie si le joueur est au sol
        estAuSol = IsGrounded();
        if (IsGrounded())
        {
            compteurDeSauts = 0;

        }
        // Si la barre d'espace est pressée et que le joueur est au sol ou qu'il peut encore sauter (double saut)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Si le joueur est au sol, ou a déjà effectué un saut (double saut), on le fait sauter
            if (estAuSol || compteurDeSauts < 1)
            {
                Sauter();
            }
        }


    }

    // Fonction pour faire sauter le joueur
    void Sauter()
    {
        // Si le joueur est au sol, réinitialise le compteur de sauts
        if (estAuSol)
        {
            compteurDeSauts = 0;  // Réinitialise le compteur à zéro lorsque le joueur touche le sol
        }
        else
        {
            compteurDeSauts++;  // Incrémente le compteur de sauts pour permettre un double saut
        }

        // Réinitialise la vitesse verticale du joueur avant d'effectuer un saut
        rb.velocity = new Vector2(rb.velocity.x, 0f);  // Réinitialise la vitesse verticale

        // Applique la force vers le haut pour faire sauter le joueur
        rb.AddForce(Vector2.up * forceDeSaut, ForceMode2D.Impulse);
    }

    // Vérifie si le joueur est au sol
    bool IsGrounded()
    {
        // Effectue un rayon vers le bas pour détecter si le joueur touche le sol
        // Le rayon est très court (0.2f) pour une détection plus précise
        return Physics2D.Raycast(transform.position, Vector2.down, 1.1f, coucheSol);
    }
}
