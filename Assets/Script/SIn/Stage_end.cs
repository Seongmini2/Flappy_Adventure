using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stage_end : MonoBehaviour
{
    public void Stage()
    {
        SceneManager.LoadScene("End_Cutscene");
        
        Debug.Log("씬 이동 성공!");
    }


}
