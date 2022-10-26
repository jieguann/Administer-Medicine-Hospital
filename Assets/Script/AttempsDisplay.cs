using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AttempsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text currentAttemps;
    [SerializeField] private List<GameObject> displayAttemps;
    // Start is called before the first frame update
    void Start()
    {   /*
        for (int i = 0; i < displayAttemps.Count; i++)
        {
            if(GameManager.Instance.currentListData.list[i] != null)
            {
                var currentList = JsonUtility.FromJson<GameManager.savedAttemps>(GameManager.Instance.currentListData.list[i]);
                displayAttemps[i].transform.GetChild(0).GetComponent<TMP_Text>().text = currentList.time;
                displayAttemps[i].transform.GetChild(1).GetComponent<TMP_Text>().text = currentList.attemps.ToString();
            }
        }
        */
        for(int i = 0; i < GameManager.Instance.currentListData.list.Count; i++)
        {
            var currentList = JsonUtility.FromJson<GameManager.savedAttemps>(GameManager.Instance.currentListData.list[i]);
            displayAttemps[i].transform.GetChild(0).GetComponent<TMP_Text>().text = currentList.time;
            displayAttemps[i].transform.GetChild(1).GetComponent<TMP_Text>().text = currentList.attemps.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAttemps.text = GameManager.Instance.attemps.ToString();
    }
}
