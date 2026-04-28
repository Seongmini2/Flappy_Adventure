using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_1 : MonoBehaviour
{
    public void Stage()
    {
        SceneManager.LoadScene("Stage_Scene 1");
        
        Debug.Log("씬 이동 성공!");
    }


}
