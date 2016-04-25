using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {


     public GameObject objTarget;
     public Vector3 offset;
     public float smoothTime = 0.1F;
     private Vector3 velocity = Vector3.zero;

     void Start()
     {
          updatePostion();
     }

     void FixedUpdate()
     {
          Vector3 targetPosition = objTarget.transform.TransformPoint(offset);
          transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, Mathf.Infinity, Time.deltaTime);

          // updatePostion();
     }

     void updatePostion()
     {
        //  Vector3 pos = objTarget.transform.localPosition;

        //  transform.localPosition = pos + offset;

          //Vector3 targetPosition = objTarget.transform.TransformPoint( offset);
          //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime,  Mathf.Infinity,  Time.deltaTime);
     }

}
