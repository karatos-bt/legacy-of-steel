using UnityEngine;

public class SautCapsule2D : MonoBehaviour
{
    public float forceDeSaut = 5f;     // Force du saut
    public LayerMask coucheSol;        // Couche du sol pour vérifier si on est au sol
    private bool estAuSol;             // Vérifie si la capsule est au sol
    private Rigidbody2D rb;            // Le Rigidbody2D de la capsule

   // bool doubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Récupère le Rigidbody2D attaché à la capsule
    }

    void Update()
    {
        // Vérifie si la capsule est au sol
        estAuSol = IsGrounded();

        // Si la barre d'espace est pressée et que la capsule est au sol, effectuer le saut
        if (Input.GetKeyDown(KeyCode.Space) && estAuSol)
        {
            Sauter();
            //doubleJump = true;
        }
       // else if (doubleJump)
      //  {
      //      doubleJump = false;
      //      rb.AddForce(Vector2.up * forceDeSaut, ForceMode2D.Impulse);
       // }
    }

    // Fonction pour sauter
    void Sauter()
    {
        // Réinitialise la vitesse verticale avant de sauter (si la capsule est en descente ou déjà en l'air)
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Réinitialise la vitesse verticale

        // Applique une force vers le haut sur le Rigidbody2D (ForceMode.Impulse pour un saut instantané)
        rb.AddForce(Vector2.up * forceDeSaut, ForceMode2D.Impulse);

    }

    // Vérifie si la capsule est au sol
    bool IsGrounded()
    {
        // Effectue un rayon vers le bas en 2D pour vérifier si on touche le sol (ajustement du rayon à 0.1f)
        return Physics2D.Raycast(transform.position, Vector2.down, 5f, coucheSol);
    }
}
