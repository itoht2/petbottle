using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;



public class SetVolumes : MonoBehaviour
{


     [SerializeField]
     UnityEngine.Audio.AudioMixer mixer;

     public string VolumeSet;
     public ScoreData scoreData;

     void Start()
     {
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();

     }


     public float masterVolume
     {
          set {
               scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();
               mixer.SetFloat(VolumeSet, Mathf.Lerp(-80, 0, value));
               float valueTemp = value;
               
               if (transform.name == "SliderBGM" ) {
                    scoreData.BGMVolume = valueTemp;
                    PlayerPrefs.SetFloat("BGMVolume", valueTemp);
                    


               } 
               if (transform.name == "SliderSE" ) {
                    scoreData.SEVolume = valueTemp;
                   PlayerPrefs.SetFloat("SEVolume", valueTemp);
               }
                    

          }

         

     }
}
