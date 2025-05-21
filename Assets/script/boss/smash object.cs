using UnityEngine;
using System.Collections;

public class SmashObject : MonoBehaviour
{
    public float fallSpeed = 10f;
    public float riseSpeed = 6f;
    public float waitOnGroundTime = 1f;

    private Vector3 startPosition;
    private Vector3 groundPosition;

    private bool isFalling = false;
    private bool isRising = false;
    private bool canDamage = false;

    public bool IsAvailableForNext { get; private set; } = true;

    public void StartSmash(Vector3 zonePosition)
    {
        groundPosition = new Vector3(zonePosition.x, 2f, zonePosition.z);
        startPosition = groundPosition + Vector3.up * 6f;
        transform.position = startPosition;

        isFalling = true;
        isRising = false;
        canDamage = false;
        IsAvailableForNext = false;
    }

    void Update()
    {
        if (isFalling)
        {
            transform.position = Vector3.MoveTowards(transform.position, groundPosition, fallSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, groundPosition) < 0.01f)
            {
                isFalling = false;
                canDamage = true; // Activer les dégâts au moment de l’écrasement
                StartCoroutine(WaitThenRise());
            }
        }
        else if (isRising)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, riseSpeed * Time.deltaTime);
            if (transform.position == startPosition)
            {
                isRising = false;
                IsAvailableForNext = true;
            }
        }
        if (isFalling && canDamage)
        {
            Debug.Log("Position de l'objet en chute : " + transform.position);
        }

    }

    IEnumerator WaitThenRise()
    {
        yield return new WaitForSeconds(waitOnGroundTime);
        canDamage = false; // Ne peut plus faire de dégâts après
        isRising = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canDamage && other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                Debug.Log("💥 Dégâts appliqués via OnTriggerStay !");
                canDamage = false; // pour éviter de faire plusieurs dégâts en une frame
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage && other.CompareTag("Player"))
        {
            // Dégâts au joueur
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                Debug.Log("💥 Le joueur a été écrasé !");
            }
        }
        else if (other.CompareTag("PlayerAttack"))
        {
            // Dégâts au boss
            BossHealth bossHealth = FindObjectOfType<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(1);
            }
        }
    }

}
