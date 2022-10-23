using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> spawnObjects;
    // Start is called before the first frame update
    void Start()
    {
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
}
