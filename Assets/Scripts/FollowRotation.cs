using UnityEngine;

public class FollowRotation : MonoBehaviour
 {
     [SerializeField] private Transform _followTransform;
     [SerializeField] private Vector3 axis = Vector3.up;

     private void LateUpdate()
     {
         if (!_followTransform)
             return;

         Vector3 targetDirection = Vector3.ProjectOnPlane(_followTransform.forward, axis);
         Quaternion targetRotation = Quaternion.LookRotation(targetDirection, axis);
         transform.rotation = targetRotation;
     }
 }