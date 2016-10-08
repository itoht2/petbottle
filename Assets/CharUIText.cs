using UnityEngine;
using UnityEngine.UI;

public class CharUIText : MonoBehaviour
{

     public Text nameText = null;
     public float risePoint;
     public float xOffSet;
     Camera cam;
     void Start()
     {
          risePoint = 2.5f;
          xOffSet = -0.8f;
          GameObject obj = GameObject.Find("Main Camera");
          cam = obj.GetComponent<Camera>();
          nameText.text = "新記録！";
     }
     void Update()
     {
          nameText.transform.position = cam.WorldToScreenPoint(new Vector3(transform.position.x + xOffSet, transform.position.y + risePoint, transform.position.z));
     }
}
