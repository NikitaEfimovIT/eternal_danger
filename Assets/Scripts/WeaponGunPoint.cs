using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGunPoint : MonoBehaviour
{
    public RawImage image;
    public Transform gunPoint;
    public float distance;

    private void Update()
    {
        Vector3 point = gunPoint.position + gunPoint.forward * distance;
        if(Physics.Raycast(gunPoint.position, gunPoint.forward, out var hitPoint, distance))
            point = hitPoint.point;

        image.rectTransform.position = Vector3.Lerp(image.rectTransform.position, Camera.main.WorldToScreenPoint(point), Time.deltaTime * 10f);
    }

    private void OnDrawGizmos()
    {
        if (Physics.Raycast(gunPoint.position, gunPoint.forward, out var hitPoint, distance))
            Gizmos.DrawLine(gunPoint.position, hitPoint.point);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitPoint.point, .1f);
    }
}
