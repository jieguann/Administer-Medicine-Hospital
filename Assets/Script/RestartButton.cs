using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "RightHand")
        {
            GameManager.Instance.OnSceneReload();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
