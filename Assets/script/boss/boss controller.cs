using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform[] attackZones; // Assign 3 points dans l'inspecteur
    public GameObject hammerPrefab; // Objet visuel du coup (ex: marteau)
    public float timeBetweenAttacks = 3f;
    public float hammerActiveTime = 1f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks)
        {
            AttackRandomZone();
            timer = 0f;
        }
    }

    void AttackRandomZone()
    {
        int randomIndex = Random.Range(0, attackZones.Length);
        Transform chosenZone = attackZones[randomIndex];

        GameObject hammer = Instantiate(hammerPrefab, chosenZone.position, Quaternion.identity);
        Destroy(hammer, hammerActiveTime);
    }
}
