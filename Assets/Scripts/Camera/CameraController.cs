using UnityEngine;
using System.Collections;
namespace Test
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private CameraTarget cameraTarget;

        [Range(1, 20)]
        public float positionStrength = 5f;

        [Range(1, 20)]
        public float rotationStrength = 5f;


        Transform TransformCamera;
        Vector3 position = Vector3.zero;
        Vector3 direction = Vector3.forward;


        void Start()
        {
            TransformCamera = transform;
        }

        void Update()
        {
            if (cameraTarget != null)
            {
                Transform targetTrans = cameraTarget.target.transform;
                position = targetTrans.transform.TransformPoint(0,cameraTarget.heightOffsetY,cameraTarget.heightOffsetZ);
                Vector3 dirCamera = cameraTarget.target.transform.rotation * Vector3.forward;
                float mag = dirCamera.magnitude;
                dirCamera.y = 0;
                if(mag > 0f)
                {
                    direction = dirCamera / mag;
                }
                
                
            }

            float delta = Time.deltaTime;
            Quaternion rot = Quaternion.LookRotation(direction);
            rot *= Quaternion.Euler(new Vector3(cameraTarget.cameraRotation, 0, 0));
            TransformCamera.position = (positionStrength == 20f) ? position : Vector3.Lerp(TransformCamera.position, position, positionStrength * delta);
            //TransformCamera.rotation = (rotationStrength == 20f) ? rot : Quaternion.Slerp(TransformCamera.rotation , rot, rotationStrength * delta * Vector3.Distance(cameraTarget.transform.position,gameObject.transform.position)*2);
            
        }
    }
}