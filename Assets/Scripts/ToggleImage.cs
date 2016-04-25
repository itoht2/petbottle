using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleImage : MonoBehaviour {
     public Graphic offGraphic;

     // Use this for initialization
     void Start () {
          Toggle toggle = GetComponent<Toggle>();
          toggle.onValueChanged.AddListener((value) => {
               OnValueChanged(value);
          });
          //初期状態を反映
          offGraphic.enabled = !toggle.isOn;
     }
	
	// Update is called once per frame
	void Update () {
	
	}
     void OnValueChanged(bool value)
     {
          if (offGraphic != null)
          {
               offGraphic.enabled = !value;
          }
     }
}
