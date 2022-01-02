using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurrent : MonoBehaviour
{
    public float turrentRotationSpeed = 150;

    public void Aim(Vector2 inputPointerPosition)
    {
        var turrentDirection = (Vector3)inputPointerPosition - transform.position;
        var desiredAngle = Mathf.Atan2(turrentDirection.y, turrentDirection.x) * Mathf.Rad2Deg;
        var rotationStep = turrentRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle), rotationStep);
    }
}
