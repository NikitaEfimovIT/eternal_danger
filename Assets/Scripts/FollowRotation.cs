using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    [SerializeField] private Transform _followTransform; // The camera or target to follow
    [SerializeField] private Transform _spineTransform;  // The body part to tilt (e.g., spine)
    [SerializeField] private Vector3 axis = Vector3.up;  // The axis to align the character's rotation
    [SerializeField] private float leanMultiplier = 1.0f; // Controls how much the character leans
    private Quaternion _defaultSpineRotation;           // Stores the initial local rotation of the spine

    private void Start()
    {
        if (_spineTransform != null)
        {
            // Store the default local rotation of the spine
            _defaultSpineRotation = _spineTransform.localRotation;
        }
    }

    private void LateUpdate()
    {
        if (!_followTransform)
            return;

        // Align the character with the camera's horizontal rotation
        Vector3 targetDirection = Vector3.ProjectOnPlane(_followTransform.forward, axis);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, axis);
        transform.rotation = targetRotation;

        // Apply leaning based on camera tilt
        if (_spineTransform)
        {
            float cameraPitch = _followTransform.localEulerAngles.x;

            // Adjust for Unity's 0-360 wraparound
            if (cameraPitch > 180) cameraPitch -= 360;

            // Combine the default rotation with the new leaning rotation
            Quaternion leanRotation = Quaternion.Euler(cameraPitch * leanMultiplier, 0, 0);
            _spineTransform.localRotation = _defaultSpineRotation * leanRotation;
        }
    }
}