using UnityEngine;
using System.Collections;

public class FollowCameraForMapcamera : MonoBehaviour {


     public GameObject objTarget;
     public Vector3 offset;
     public float smoothTime = 0.1F;
     private Vector3 velocity = Vector3.zero;
    

     void Start()
     {
          
     }

     void FixedUpdate()
     {
          Vector3 targetPosition = objTarget.transform.TransformPoint(offset);
          transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, Mathf.Infinity, Time.deltaTime);

        
         
     }

     
}
