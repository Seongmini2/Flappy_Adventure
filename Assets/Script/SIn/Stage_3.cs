using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_3 : MonoBehaviour
{
    public void Stage()
    {
        SceneManager.LoadScene("Stage_Scene 3");
        
        Debug.Log("씬 이동 성공!");
    }
}
