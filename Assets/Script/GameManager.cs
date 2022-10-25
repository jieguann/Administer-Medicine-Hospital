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
        //public string name;
        public List<string> list = new List<string>();
    }

    //private string saveDataKey = "saveDataKey";
    private saveList saveListData = new saveList();
    private saveList currentListData = new saveList();
    private savedAttemps saveAttempsData = new savedAttemps();
    //private List<savedAttemps> tempList = new List<savedAttemps>();


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

        //saveListData.list = new List<savedAttemps>();
        currentListData.list = JsonUtility.FromJson<saveList>(System.IO.File.ReadAllText(Application.persistentDataPath + "/AttempsData.json")).list;

        if (currentListData.list.Count > 2)
        {
            saveListData.list.Add(currentListData.list[1]);
            saveListData.list.Add(currentListData.list[2]);
        }

        else
        {
            saveListData.list = currentListData.list;
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
    {
        /*
        if (saveListData.list.Count == 2) {
            saveListData.list.RemoveAt(0);
        }
        */
        saveAttempsData.attemps = 1;
        saveAttempsData.time = System.DateTime.Now.ToString();
        var saveAttempsDataJson = JsonUtility.ToJson(saveAttempsData);

        //tempList.Add(new savedAttemps { attemps = 3, time = System.DateTime.Now.ToString() }) ;
        //tempList[tempList.Count - 1].attemps = 1;
        //tempList[tempList.Count - 1].time = System.DateTime.Now.ToString();
        //print(tempList[tempList.Count - 1].attemps);
        //saveListData.list = tempList;
        saveListData.list.Add(saveAttempsDataJson);
        //saveListData.name = "jie guan";


        //PlayerPrefs.SetString(saveDataKey , JsonUtility.ToJson(saveListData));
        //

        //Debug.Log(Application.persistentDataPath);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/AttempsData.json", JsonUtility.ToJson(saveListData));
    }
}
