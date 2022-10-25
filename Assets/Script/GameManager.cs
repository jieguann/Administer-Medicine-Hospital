using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager is null");
            }

            return _instance;
        }
    }
    public class savedAttemps
    {
        public string time;
        public int attemps;
    }

    public class saveList
    {
        public List<savedAttemps> list;
    }

    private string saveDataKey = "saveDataKey";
    //private savedAttemps[] saveAttempsData = new savedAttemps[3];
    //private savedAttemps[] savedTempData = new savedAttemps[2];


    public int attemps = 0;
    [SerializeField] private Transform cameraHMD;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> spawnObjects;

    [SerializeField] private GameObject tipsPrefeb;
    public int orderFlag;
    public float assembledPercentage = 0;

    private void Awake()
    {
        _instance = this;


        
    }
    // Start is called before the first frame update
    void Start()
    {
       
            
            if (PlayerPrefs.HasKey(saveDataKey + i.ToString()))
            {

                //saveAttempsData[i] = JsonUtility.FromJson<savedAttemps>(PlayerPrefs.GetString(saveDataKey+i.ToString()));
                
                
                //print(savedTempData[i].time);
                //print(saveAttempsData[i].time);
            }
            else
            {
                //saveAttempsData[i].time = "N/A";
                //saveAttempsData[i].attemps = 0;
            }


            
        

        

        orderFlag = 0;

        for(int i=0; i < spawnPoints.Count; i++)
        {
            int randomIndex = Random.Range(0, spawnObjects.Count-1);
            Instantiate(spawnObjects[randomIndex], spawnPoints[i]);
            spawnObjects.Remove(spawnObjects[randomIndex]);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void errorTips()
    {
        var tips = Instantiate(tipsPrefeb, cameraHMD);
        Destroy(tips, 2);
    }


    public IEnumerator assembleSyringe()
    {
        while (assembledPercentage < 100)
        {
            yield return new WaitForSeconds(0.5f);
            assembledPercentage += 5;
        }

        if (assembledPercentage == 100)
        {
            orderFlag += 1;
        }
        
    }

    public IEnumerator injectPatient()
    {
        while (assembledPercentage > 0)
        {
            yield return new WaitForSeconds(0.5f);
            assembledPercentage -= 5;
        }

        if (assembledPercentage == 0)
        {
            orderFlag += 1;
        }

    }


    void OnApplicationQuit()
    {//Debug.Log("Application ending after " + Time.time + " seconds");

       
        
        

        saveAttempsData[2].attemps = attemps;
        saveAttempsData[2].time = System.DateTime.Now.ToString();

        for (int i = 0; i < saveAttempsData.Length; i++)
        {
            
            PlayerPrefs.SetString(saveDataKey + i.ToString(), JsonUtility.ToJson(saveAttempsData[i]));
            print(saveAttempsData[i].time);
        }

    }
}
