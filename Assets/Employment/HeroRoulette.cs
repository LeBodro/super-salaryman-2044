using UnityEngine;

public class HeroRoulette : MonoBehaviour
{
    int selectionCount;

    void Start()
    {
        selectionCount = transform.childCount - 1;
        int nextHeroIndex = Random.Range(0, transform.childCount);
        SetHero(nextHeroIndex);
    }

    public void Turn()
    {
        int nextHeroIndex = Random.Range(0, selectionCount);
        SetHero(nextHeroIndex);
    }

    void SetHero(int index)
    {
        transform.GetChild(selectionCount).gameObject.SetActive(false);
        var nextHero = transform.GetChild(index);
        nextHero.gameObject.SetActive(true);
        nextHero.SetAsLastSibling();
    }

    public bool debug;

    void Update()
    {
        if (debug)
        {
            debug = false;
            Turn();
        }
    }
}
