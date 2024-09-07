using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
}
