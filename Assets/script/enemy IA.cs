using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 10f;

    private Transform player;
    private bool isFacingRight = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("❌ Le joueur n'a pas été trouvé ! Vérifie son tag !");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distance joueur: " + distance);

        if (distance <= detectionRange)
        {
            //Vector3 direction = (player.position - transform.position).normalized;
            Vector3 direction = (new Vector3 (player.position.x - transform.position.x, 0, 0)).normalized;
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
