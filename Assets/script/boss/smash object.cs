using UnityEngine;


public class BossHammer : MonoBehaviour
{
    public int damageToPlayer = 1;
    public int damageFromPlayer = 1;
    public float fallSpeed = 10f;
    public float groundY = 0f; // La hauteur du sol

    private bool hasHitGround = false;

    void Update()
    {
        if (!hasHitGround)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, groundY), fallSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.position.y - groundY) < 0.1f)
            {
                hasHitGround = true;
                // Tu peux ajouter un effet ici (particules, secousse...)
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage(damageToPlayer);
        }
        else if (other.CompareTag("PlayerAttack"))
        {
            GameObject.FindObjectOfType<BossHealth>()?.TakeDamage(damageFromPlayer);
        }
    }
}
