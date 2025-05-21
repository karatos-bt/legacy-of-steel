using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public GameObject smashObjectPrefab;
    public Transform[] smashZones; // 3 zones dans l'inspecteur
    public float delayBetweenZones = 1.2f;

    private GameObject smashObjectInstance;

    void Start()
    {
        // Créer l'objet une seule fois
        smashObjectInstance = Instantiate(smashObjectPrefab);
        StartCoroutine(SmashCycle());
    }

    IEnumerator SmashCycle()
    {
        while (true)
        {
            int randomZone = Random.Range(0, smashZones.Length);
            Transform targetZone = smashZones[randomZone];

            // Démarre le smash sur une zone aléatoire
            SmashObject smashScript = smashObjectInstance.GetComponent<SmashObject>();
            smashScript.StartSmash(targetZone.position);

            // Attendre que le smash soit terminé (descente, pause, remontée)
            while (!smashScript.IsAvailableForNext)
                yield return null;

            yield return new WaitForSeconds(delayBetweenZones);
        }
    }
}
