using UnityEngine;

public class DoubleJump2D : MonoBehaviour
{
    public float forceDeSaut = 5f;        // Force du saut
    public LayerMask coucheSol;           // Layer mask pour d�tecter le sol
    private Rigidbody2D rb;               // Le Rigidbody2D du joueur
    private bool estAuSol;                // V�rifie si le joueur est au sol
    private int compteurDeSauts;          // Compteur de sauts effectu�s

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // R�cup�re le Rigidbody2D du joueur
        compteurDeSauts = 0;               // Initialisation du compteur de sauts
    }

    void Update()
    {
        // V�rifie si le joueur est au sol
        estAuSol = IsGrounded();
        if (IsGrounded())
        {
            compteurDeSauts = 0;

        }
        // Si la barre d'espace est press�e et que le joueur est au sol ou qu'il peut encore sauter (double saut)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Si le joueur est au sol, ou a d�j� effectu� un saut (double saut), on le fait sauter
            if (estAuSol || compteurDeSauts < 1)
            {
                Sauter();
            }
        }


    }

    // Fonction pour faire sauter le joueur
    void Sauter()
    {
        // Si le joueur est au sol, r�initialise le compteur de sauts
        if (estAuSol)
        {
            compteurDeSauts = 0;  // R�initialise le compteur � z�ro lorsque le joueur touche le sol
        }
        else
        {
            compteurDeSauts++;  // Incr�mente le compteur de sauts pour permettre un double saut
        }

        // R�initialise la vitesse verticale du joueur avant d'effectuer un saut
        rb.velocity = new Vector2(rb.velocity.x, 0f);  // R�initialise la vitesse verticale

        // Applique la force vers le haut pour faire sauter le joueur
        rb.AddForce(Vector2.up * forceDeSaut, ForceMode2D.Impulse);
    }

    // V�rifie si le joueur est au sol
    bool IsGrounded()
    {
        // Effectue un rayon vers le bas pour d�tecter si le joueur touche le sol
        // Le rayon est tr�s court (0.2f) pour une d�tection plus pr�cise
        return Physics2D.Raycast(transform.position, Vector2.down, 1.1f, coucheSol);
    }
}
