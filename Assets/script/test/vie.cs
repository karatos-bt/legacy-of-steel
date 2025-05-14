using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vie : MonoBehaviour
{

    static Image Barre;

    public float max { get; set; }

    private float Valeur;
    public float valeur
    {
        get { return Valeur; }

        set
        {
            Valeur = Mathf.Clamp(value, 0, max);
            if (Barre != null)
            {
                Barre.fillAmount = (1 / max) * Valeur;

            }
        }

    }

    void Start()
    {
        Barre = GetComponent<Image>();

    }
}

