using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {


     public GameObject objTarget;
     public Vector3 offset;
     public float smoothTime = 0.1F;
     private Vector3 velocity = Vector3.zero;
     public Camera mainCamera;
     public SpecData specData;

     void Start()
     {
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          StartCoroutine(LastFixedUpdate());
     }


     //void FixedUpdate()
     //{        

     //     Vector3 targetPosition = objTarget.transform.TransformPoint(offset);
     //     transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, Mathf.Infinity, Time.deltaTime);

     //     float Altitude = specData.GetAltitude();

     //     if (Altitude > 100.0f)
     //     {
     //          mainCamera.orthographicSize = Altitude * 0.06f;
     //     }
     //     else
     //     {
     //          mainCamera.orthographicSize = 6.0f;
     //     }

     //}

     IEnumerator LastFixedUpdate()
     {
          while (true)
          {
               yield return new WaitForFixedUpdate();

               Vector3 targetPosition = objTarget.transform.TransformPoint(offset);
               transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, Mathf.Infinity, Time.deltaTime);

               float Altitude = specData.GetAltitude();

               if (Altitude > 100.0f)
               {
                    mainCamera.orthographicSize = Altitude * 0.06f;
               }
               else
               {
                    mainCamera.orthographicSize = 6.0f;
               }

          }
     }
}
