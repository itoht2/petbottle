using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerPrefs = PreviewLabs.PlayerPrefs;


public class OnStartTitleScript : MonoBehaviour {

     [SerializeField]
     Animator
       animator;

     public Slider BGMVolumeSlider;
     public Slider SEVolumeSlider;
     public UnityEngine.Audio.AudioMixer BGMVol;

     public ScoreData scoreData;

	// Use this for initialization
	void Awake () {
         

          GameObject IsSpecData = GameObject.Find("SpecData");
          GameObject IsScoreData = GameObject.Find("ScoreData");
          GameObject IsBodyFolder = GameObject.Find("BodyFolder");
          GameObject IsNoseCornFolder = GameObject.Find("NoseCornFolder");
          GameObject IsFinFolder = GameObject.Find("FinFolder");
          GameObject IsCanSatFolder = GameObject.Find("CanSatFolder");

          GameObject IsSRBAFolder = GameObject.Find("SRBAFolder");
          GameObject IsPumpFolder = GameObject.Find("PumpFolder");
          GameObject IsMultiStageFolder = GameObject.Find("MultiStageFolder");
          GameObject IsAwardFlags = GameObject.Find("AwardFlags");
          // ふらぐのフォルダーもいれる　未実装


          if (IsSpecData == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/SpecData");
               IsSpecData = Instantiate(SpecDataprefab);
               IsSpecData.name = "SpecData";
               DontDestroyOnLoad(IsSpecData);
          }

          if(IsScoreData == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/ScoreData");
               IsScoreData = Instantiate(SpecDataprefab);
               IsScoreData.name = "ScoreData";
               DontDestroyOnLoad(IsScoreData);
          }

          if (IsBodyFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/BodyFolder");
               IsBodyFolder = Instantiate(SpecDataprefab);
               IsBodyFolder.name = "BodyFolder";
               DontDestroyOnLoad(IsBodyFolder);
          }

          if (IsNoseCornFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/NoseCornFolder");
               IsNoseCornFolder = Instantiate(SpecDataprefab);
               IsNoseCornFolder.name = "NoseCornFolder";
               DontDestroyOnLoad(IsNoseCornFolder);
          }

          if (IsFinFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/FinFolder");
               IsFinFolder = Instantiate(SpecDataprefab);
               IsFinFolder.name = "FinFolder";
               DontDestroyOnLoad(IsFinFolder);
          }

          if (IsCanSatFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/CanSatFolder");
               IsCanSatFolder = Instantiate(SpecDataprefab);
               IsCanSatFolder.name = "CanSatFolder";
               DontDestroyOnLoad(IsCanSatFolder);
          }

          if (IsSRBAFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/SRBAFolder");
               IsSRBAFolder = Instantiate(SpecDataprefab);
               IsSRBAFolder.name = "SRBAFolder";
               DontDestroyOnLoad(IsSRBAFolder);
          }

          if (IsPumpFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/PumpFolder");
               IsPumpFolder = Instantiate(SpecDataprefab);
               IsPumpFolder.name = "PumpFolder";
               DontDestroyOnLoad(IsPumpFolder);
          }

          if (IsMultiStageFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/MultiStageFolder");
               IsMultiStageFolder = Instantiate(SpecDataprefab);
               IsMultiStageFolder.name = "MultiStageFolder";
               DontDestroyOnLoad(IsMultiStageFolder);
          }

          if (IsAwardFlags == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/AwardFlags");
               IsAwardFlags = Instantiate(SpecDataprefab);
               IsAwardFlags.name = "AwardFlags";
               DontDestroyOnLoad(IsAwardFlags);
          }

          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();

          

     }

     void Start()
     {

          BGMVolumeSlider.value = scoreData.GetBGMVolume();
          SEVolumeSlider.value = scoreData.GetSEVolume();

          BGMVol.SetFloat("BGM", Mathf.Lerp(-80, 0, scoreData.GetBGMVolume()));
          BGMVol.SetFloat("Sounds", Mathf.Lerp(-80, 0, scoreData.GetSEVolume()));

          StartCoroutine(TitleRocketFlyer());


     }


          // Update is called once per frame
     void Update ()
     {

          //if (Input.GetKeyDown(KeyCode.UpArrow))
          //     animator.SetBool("Fly", true);
          //if (Input.GetKeyDown(KeyCode.DownArrow))
          //     animator.SetBool("Fly", false);
     }

     public void OnApplicationQuit()
     {
          PlayerPrefs.Flush();
     }

     IEnumerator TitleRocketFlyer()
     {
          while (true)
          {
               // Do anything

               yield return new WaitForSeconds(30.0f);
               animator.SetBool("Fly", true);

               yield return new WaitForSeconds(0.5f);
               animator.SetBool("Fly", false);
          }
     }
}
