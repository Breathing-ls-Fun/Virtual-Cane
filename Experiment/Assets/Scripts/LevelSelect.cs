using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LoadMap1()
    {
        SceneManager.LoadScene("Map 1");
    }
    public void LoadMap2()
    {
        SceneManager.LoadScene("Map 2");
    }
    public void LoadMap3()
    {
        SceneManager.LoadScene("Map 3");
    }
    public void LoadMap4()
    {
        SceneManager.LoadScene("Map 4");
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadTestMap()
    {
        SceneManager.LoadScene("test");
    }
}
