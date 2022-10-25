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
            yield return new WaitForSeconds(1.0f);
            assembledPercentage += 5;
        }

        if (assembledPercentage == 100)
        {
            orderFlag += 1;
        }
        
    }
}
