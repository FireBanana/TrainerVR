using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : Usable
{
    int currentLevel = 1;
    Vector3 lastPosition = Vector3.zero;

    float totalX, totalZ;

    public override void Use(Vector3 startPosition, Vector3 currentPosiiton)
    {
        transform.up = currentPosiiton - transform.position;

        //if (lastPosition == Vector3.zero)
        //    lastPosition = currentPosiiton;

        //var eulerRot = transform.eulerAngles;
        //var newRotation = eulerRot;

        //var to = currentPosiiton - transform.position;
        //var from = lastPosition - transform.position;

        //var angleX = Vector3.SignedAngle(from, to, transform.right);
        //var angleZ = Vector3.SignedAngle(from, to, transform.forward);

        //if(Mathf.Abs(totalX + angleX) < 22)
        //{
        //    totalX += angleX;
        //    newRotation.x += angleX;
        //}

        //if (Mathf.Abs(totalZ + angleZ) < 22)
        //{
        //    totalZ += angleZ;
        //    newRotation.z += angleZ;
        //}

        //transform.eulerAngles = Vector3.Lerp(eulerRot, newRotation, 10);
        //lastPosition = currentPosiiton;
    }

    public override void Released()
    {
        lastPosition = Vector3.zero;
    }

    bool CanMoveHorizontal(Vector3 eulerRatation)
    {
        if(eulerRatation.x >= -3 && eulerRatation.x <= 3)
            return true;

        return false;
    }

    bool CanMoveVertical(Vector3 eulerRatation)
    {
        var z = eulerRatation.z;

        if (z >= -22 && z <= -17 || z >= -3 && z <= 3 || z >= 22 && z <= 17)
            return true;

        return false;
    }
}