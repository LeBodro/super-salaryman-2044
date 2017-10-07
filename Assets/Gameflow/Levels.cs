using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    /* Cette classe a pour destin d'être sur un prefab.
     * Ce prefab agira comme une config manuelle de niveaux pour faciliter le level design.
     * On pourra faire différentes configs si on veut (mettons une par difficulté) et ultimement glisser cette config dans le gamecontroller
     * pour qu'il s'en serve.
     * */

    [SerializeField] WorkDay[] days;
    [SerializeField] int maxJobCount;

    int currentLevel = 0;

    public void StartNext()
    {
        //starts next level
    }

    public void EndCurrent()
    {
        //ends current level
        currentLevel++;
        if (days[currentLevel].AddsJob)
        {
            // add a job to pool
            // if this brings us over maximum, change a job instead
        }
    }
}
