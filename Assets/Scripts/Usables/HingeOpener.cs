using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HingeOpener : Usable
{
    public enum DoorType
    {
        Hood,
        Trunk,
        DoorLeft,
        GasLid
    }

    public DoorType doorType;

    bool isAnimating;
    bool isOpen;

    public override void Use(Vector3 localPosition, Vector3 currentPosiiton, Transform controllerTransform)
    {
        if (isAnimating)
            return;

        isAnimating = true;
        Toggle();
    }

    void Toggle()
    {
        if (isOpen)
        {

            isOpen = false;
            switch (doorType)
            {
                case DoorType.Hood:
                    transform.parent.DORotate(transform.parent.eulerAngles + new Vector3(-50, 0, 0), 4).OnComplete(() => { isAnimating = false; });
                    break;
                case DoorType.Trunk:
                    transform.parent.DORotate(transform.parent.eulerAngles + new Vector3(-70, 0, 0), 4).OnComplete(() => { isAnimating = false; });
                    break;
                case DoorType.DoorLeft:
                    //transform.parent.DORotate(transform.parent.eulerAngles + new Vector3(-50, 0, 0), 4).OnComplete(() => { isAnimating = false; });
                    break;
                case DoorType.GasLid:
                    //transform.parent.DORotate(transform.parent.eulerAngles + new Vector3(-50, 0, 0), 4).OnComplete(() => { isAnimating = false; });
                    break;
            }    
            
        }
        else
        {
            isOpen = true;
            switch (doorType)
            {
                case DoorType.Hood:
                    transform.parent.DORotate(transform.parent.eulerAngles + new Vector3(50, 0, 0), 4).OnComplete(() => { isAnimating = false; });
                    break;
                case DoorType.Trunk:
                    transform.parent.DORotate(transform.parent.eulerAngles + new Vector3(-70, 0, 0), 4).OnComplete(() => { isAnimating = false; });
                    break;
                case DoorType.DoorLeft:
                    //transform.parent.DORotate(transform.parent.eulerAngles + new Vector3(-50, 0, 0), 4).OnComplete(() => { isAnimating = false; });
                    break;
                case DoorType.GasLid:
                    //transform.parent.DORotate(transform.parent.eulerAngles + new Vector3(-50, 0, 0), 4).OnComplete(() => { isAnimating = false; });
                    break;
            }
        }
    }
}
