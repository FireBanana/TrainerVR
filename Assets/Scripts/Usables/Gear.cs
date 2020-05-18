using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SocialPlatforms;

public class Gear : Usable
{
    Dictionary<int, Vector3> GearPositions = new Dictionary<int, Vector3>()
    {
        {1, new Vector3(0.1145f, -0.3478904f, -0.4169f) },
        {2, new Vector3(0.1145f, -0.3478904f, -0.3407f) },
        {3, new Vector3(0.1145f, -0.3478904f,-0.2645f) },
        {4, new Vector3(0.0546f, -0.3478904f, -0.4169f) },
        {5, new Vector3(0.0546f, -0.3478904f, -0.3407f) },
        {6, new Vector3(0.0546f, -0.3478904f, -0.2645f) },
        {7, new Vector3(-0.0053f, -0.3478904f, -0.4169f) },
        {8, new Vector3(-0.0053f, -0.3478904f, -0.3407f) },
        {9, new Vector3(-0.0053f, -0.3478904f, -0.2645f) }
    };

    float verticalLength = 0.0762f, horizontalLength = 0.0599f;
    Vector3 defaultPosition;
    Vector3 lastPosition = Vector3.zero;

    private void Start()
    {
        defaultPosition = transform.position;
    }
    public override void Use(Vector3 localPosition, Vector3 currentPosition, Transform controllerTransform)
    {
        var root = CarController.Instance.transform.position;
        var relativeControllerPos = currentPosition - root;
        var relativeGearPos = transform.position - root;
        //---------- TEST THIS OUT

        if (lastPosition == Vector3.zero)
            lastPosition = relativeControllerPos;

        var delta = relativeControllerPos - lastPosition;

        var calculatedX = Mathf.Clamp(transform.position.x + delta.x, defaultPosition.x - horizontalLength, defaultPosition.x + horizontalLength);
        var calculatedZ = Mathf.Clamp(transform.position.z + delta.z, defaultPosition.z - verticalLength, defaultPosition.z + verticalLength);

        transform.position = new Vector3(calculatedX, transform.position.y, calculatedZ);

        lastPosition = relativeControllerPos;
    }

    void ResolvePosition()
    {

    }

    public override void Released()
    {
        ResolvePosition();
    }
}

/* The unperformant way
 
var transformedPosition = controllerTransform.InverseTransformPoint(transform.position);

        if (lastPosition == Vector3.zero)
            lastPosition = localPosition;

        var newPositionDelta = new Vector3(localPosition.x - lastPosition.x, transformedPosition.y, localPosition.z - lastPosition.z);

        transformedPosition += newPositionDelta;

        var retransformedPosition = controllerTransform.TransformPoint(transformedPosition);

        transform.position = new Vector3(retransformedPosition.x, transform.position.y, retransformedPosition.z);

        lastPosition = localPosition;
        
*/
