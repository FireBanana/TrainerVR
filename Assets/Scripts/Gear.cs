using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Gear : Usable
{
    struct GearPoint
    {
        public List<int> neighbourPoints;
        Vector3 eulerRotation;

        public GearPoint(Vector3 _eulerRotation, IEnumerable<int> nPoints)
        {
            eulerRotation = _eulerRotation;
            neighbourPoints = nPoints.ToList();
        }
    }

    // 1-index based (9-reverse)
    Dictionary<int, GearPoint> gearPoints = new Dictionary<int, GearPoint>()
    {
        {1, new GearPoint(new Vector3(-22.7f, 8, -20), new[]{2} )},
        {2, new GearPoint(new Vector3(0, 0, -18.3f), new[]{1, 3, 5} ) },
        {3, new GearPoint(new Vector3(15.5f, -5.3f, -19), new[]{2} ) },
        {4, new GearPoint(new Vector3(-26, 0, 0), new[]{5} ) },
        {5, new GearPoint(new Vector3(0, 0, 0), new[]{2, 4, 6, 8} ) },
        {6, new GearPoint(new Vector3(21.7f, 0, 0), new[]{5} ) },
        {7, new GearPoint(new Vector3(-28, -11.3f, 23.1f), new[]{8} ) },
        {8, new GearPoint(new Vector3(0, 0, 18), new[]{7, 5, 9} ) },
        {9, new GearPoint(new Vector3(9.7f, 3.6f, 19), new[]{8} ) }
    };

    private void Start()
    {
    }

    public override void Use(Vector3 startPosition, Vector3 currentPosition, Transform controllerTransform)
    {

    }

    public override void Released()
    {

    }

    bool CanMoveHorizontal(Vector3 eulerRatation)
    {
        return false;
    }

    bool CanMoveVertical(Vector3 eulerRatation)
    {
        return false;
    }
}