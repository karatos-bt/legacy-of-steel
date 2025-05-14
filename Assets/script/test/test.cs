using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    vie BarreDeVie = new vie();
    void Start()
    {
        BarreDeVie.max = 100;
        BarreDeVie.valeur = 100;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            BarreDeVie.valeur -= 10;

        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            BarreDeVie.valeur += 10;

        }

    }
}
