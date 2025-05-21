using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int attackDamage = 1;
    public float attackRate = 3f;
    public LayerMask playerLayer;
    public Transform attackPoint;

    private float nextAttackTime = 0f;

    void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        if (player != null && Time.time >= nextAttackTime)
        {
            player.GetComponent<PlayerHealth>()?.TakeDamage(attackDamage);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

