using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cones : MonoBehaviour
{
    public List<IndividualCone> ConeList;
    public List<Collectible> Collectibles;

    public int[] Evaluate()
    {
        var totalHits = 0;
        var conesMoved = 0;
        var collectibles = 0;

        foreach(var cone in ConeList)
        {
            totalHits += cone.Hits;
            if (cone.HasCollided)
                conesMoved++;
        }

        foreach (var collectible in Collectibles)
        {
            if (collectible.HasCollected)
                collectibles++;
        }

        return new int[] { conesMoved, totalHits, collectibles};
    }
}
