using UnityEngine;

namespace Camera
{
    public class CameraFollowScript : MonoBehaviour
    {
        private UnityEngine.Camera camera;
    
        [SerializeField]
        private Transform target;

        [SerializeField] 
        private float cameraMoveSmoothSpeed;
    
        [SerializeField] 
        private float cameraZoomSmoothSpeed;

        [SerializeField] 
        private float zoomSpeed;

        [SerializeField] 
        private float maxCameraSize;

        [SerializeField] 
        private float minCameraSize;

        private float orthographicSize;

        private void Start()
        {
            camera = GetComponentInChildren<UnityEngine.Camera>();
            orthographicSize = camera.orthographicSize;
        }

        private void Update()
        {
            ZoomCamera();
        }

        private void FixedUpdate()
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            var desiredPosition = target.position;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraMoveSmoothSpeed);
            transform.position = smoothedPosition; 
        }

        private void ZoomCamera()
        {
            var mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            orthographicSize += mouseScroll * zoomSpeed;
            orthographicSize = Mathf.Clamp(orthographicSize, minCameraSize, maxCameraSize);
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, orthographicSize, 
                cameraZoomSmoothSpeed);
        }
    }
}
