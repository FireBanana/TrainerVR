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
    public Transform defaultTransform;
    Vector3 lastPosition = Vector3.zero;

    public override void Use(Vector3 localPosition, Vector3 currentPosition, Transform controllerTransform)
    {
        var root = CarController.Instance.transform.position;
        var relativeControllerPos = currentPosition - root;
        var position = transform.position;
        //---------- TEST THIS OUT

        if (lastPosition == Vector3.zero)
            lastPosition = relativeControllerPos;

        var delta = relativeControllerPos - lastPosition;

        var calculatedX = Mathf.Clamp(position.x + delta.x, defaultTransform.position.x - horizontalLength, defaultTransform.position.x + horizontalLength);
        var calculatedZ = Mathf.Clamp(position.z + delta.z, defaultTransform.position.z - verticalLength, defaultTransform.position.z + verticalLength);

        var finalX = position.z > defaultTransform.position.z - 0.01f && position.z < defaultTransform.position.z + 0.01f ? calculatedX : position.x;
        //Take a gear from each column
        var finalZ = position.x > (defaultTransform.position.x - 0.0599f) - 0.01f && position.x < (defaultTransform.position.x - 0.0599f) + 0.01f ||
            position.x >= defaultTransform.position.x - 0.01f && position.x <= defaultTransform.position.x + 0.01f ||
            position.x > (defaultTransform.position.x + 0.0599f) - 0.01f && position.x < (defaultTransform.position.x + 0.0599f) + 0.01f ? calculatedZ : position.z;

        transform.position = new Vector3(finalX, transform.position.y, finalZ);

        lastPosition = relativeControllerPos;
    }

    void ResolvePosition()
    {
        //Release the gear to the nearest gear
        var finalLocalPosition = Vector3.zero;

        //First Column
        if(transform.localPosition.x > (defaultTransform.localPosition.x - 0.0599f) -  0.0599f / 2 && transform.localPosition.x < (defaultTransform.localPosition.x - 0.0599f) + 0.0599f / 2)
        {
            finalLocalPosition.x = defaultTransform.localPosition.x - 0.0599f;
        }
        else if(transform.localPosition.x >= (defaultTransform.localPosition.x) - 0.0599f / 2 && transform.localPosition.x <= (defaultTransform.localPosition.x) + 0.0599f / 2)
        {
            finalLocalPosition.x = defaultTransform.localPosition.x;
        }
        else if(transform.localPosition.x > (defaultTransform.localPosition.x + 0.0599f) - 0.0599f / 2 && transform.localPosition.x < (defaultTransform.localPosition.x + 0.0599f) + 0.0599f / 2)
        {
            finalLocalPosition.x = defaultTransform.localPosition.x + 0.0599f;
        }

        if(transform.localPosition.z > (defaultTransform.localPosition.z - 0.0762f) - 0.0762f / 2 && transform.localPosition.z < (defaultTransform.localPosition.z - 0.0762f) + 0.0762f / 2)
        {
            finalLocalPosition.z = defaultTransform.localPosition.z - 0.0762f;
        }
        else if (transform.localPosition.z >= (defaultTransform.localPosition.z) - 0.0762f / 2 && transform.localPosition.z <= (defaultTransform.localPosition.z) + 0.0762f / 2)
        {
            finalLocalPosition.z = defaultTransform.localPosition.z;
        }
        else if (transform.localPosition.z > (defaultTransform.localPosition.z + 0.0762f) - 0.0762f / 2 && transform.localPosition.z < (defaultTransform.localPosition.z + 0.0762f) + 0.0762f / 2)
        {
            finalLocalPosition.z = defaultTransform.localPosition.z + 0.0762f;
        }

        transform.localPosition = new Vector3(finalLocalPosition.x, transform.localPosition.y, finalLocalPosition.z);
    }

    public override void Released()
    {
        lastPosition = Vector3.zero;
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
