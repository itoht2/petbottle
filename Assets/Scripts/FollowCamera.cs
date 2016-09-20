using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {


     public GameObject objTarget;
     public Vector3 offset;
     public float smoothTime = 0.1F;
     private Vector3 velocity = Vector3.zero;
     public Camera mainCamera;
     public SpecData specData;
     public Color BGColor;
     
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

               if (Altitude <= 20000)
               {

                    mainCamera.backgroundColor = Color.Lerp(GetRgbColor(0x9BB9FF), GetRgbColor(0x001B58),Altitude / 20000);

                    
               } else if (Altitude <= 100000) 
               {

                    mainCamera.backgroundColor = Color.Lerp(GetRgbColor(0x001B58), GetRgbColor(0x000000), (Altitude - 20000) / 80000);
                
               } else
               {
                    mainCamera.backgroundColor = GetRgbColor(0x000000);
               }


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

     public static Color GetRgbColor(uint color)
     {
          float r, g, b, a;
          var inv = 1.0f / 255.0f;
          if (color > 0xffffff)
          {
               r = ((color >> 24) & 0xff) * inv;
               g = ((color >> 16) & 0xff) * inv;
               b = ((color >> 8) & 0xff) * inv;
               a = ((color) & 0xff) * inv;
          }
          else
          {
               r = ((color >> 16) & 0xff) * inv;
               g = ((color >> 8) & 0xff) * inv;
               b = ((color) & 0xff) * inv;
               a = 1.0f;
          }
          return new Color(r, g, b, a);
     }
}
