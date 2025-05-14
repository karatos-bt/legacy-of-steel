using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    public float attackRate = 2f;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.P)) // Touche d'attaque
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // Animation ici (si tu en as une)
        Debug.Log("Attaque !");

        // Détecte les ennemis dans le rayon d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Inflige des dégâts aux ennemis détectés
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}