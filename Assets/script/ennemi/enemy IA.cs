using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 10f;

    private Transform player;
    private bool isFacingRight = true;
    private EnemyAttack enemyAttack; // ✅ ajouté

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        enemyAttack = GetComponent<EnemyAttack>(); // ✅ ajouté

        if (player == null)
        {
            Debug.LogError("❌ Le joueur n'a pas été trouvé ! Vérifie son tag !");
        }
    }

    void Update()
    {
        if (player == null || enemyAttack == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distance joueur: " + distance);

        if (distance <= detectionRange && !enemyAttack.IsPlayerInAttackRange) // ✅ on ne bouge que si le joueur n'est pas dans la zone d'attaque
        {
            Vector3 direction = new Vector3(player.position.x - transform.position.x, 0, 0).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (direction.x < 0 && !isFacingRight)
            {
                Flip();
            }
            else if (direction.x > 0 && isFacingRight)
            {
                Flip();
            }
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
