using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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
    public saveList currentListData = new saveList();
    private savedAttemps saveAttempsData = new savedAttemps();
    //private List<savedAttemps> tempList = new List<savedAttemps>();


    public int attemps = 0;
    [SerializeField] private Transform cameraHMD;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> spawnObjects;

    [SerializeField] private GameObject tipsPrefeb;
    public int orderFlag;
    public float assembledPercentage = 0;

    [SerializeField] Transform leftHand;
    [SerializeField] GameObject resetButtonPrefeb;


    private void Awake()
    {
        _instance = this;

        if (File.Exists(Application.persistentDataPath + "/AttempsData.json"))
        {
            //saveListData.list = new List<savedAttemps>();
            currentListData.list = JsonUtility.FromJson<saveList>(File.ReadAllText(Application.persistentDataPath + "/AttempsData.json")).list;

            if (currentListData.list.Count > 2)
            {
                saveListData.list.Add(currentListData.list[1]);
                saveListData.list.Add(currentListData.list[2]);
            }

            else
            {
                saveListData.list = currentListData.list;
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
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
        attemps += 1;
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
            OnComplete();
        }

    }


    public void OnComplete()
    {
        print("complete");
        Instantiate(resetButtonPrefeb, leftHand); 
    }

    public void OnSceneReload()
    {
        
        saveAttempsData.attemps = attemps;
        saveAttempsData.time = System.DateTime.Now.ToString();
        var saveAttempsDataJson = JsonUtility.ToJson(saveAttempsData);

        
        saveListData.list.Add(saveAttempsDataJson);
       
        File.WriteAllText(Application.persistentDataPath + "/AttempsData.json", JsonUtility.ToJson(saveListData));
    }
}
