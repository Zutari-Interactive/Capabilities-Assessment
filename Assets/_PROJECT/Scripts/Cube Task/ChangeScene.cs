using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    #region PROPERTIES 
    private enum Scene
    {
        Main, 
        LevelOne
    }
    #endregion


    #region VARAIBLES 
    [SerializeField]
    private Scene scene;
    #endregion


    #region PUBLIC API
    public void OnClickChangeScene()
    {
        SceneManager.LoadScene(scene.ToString());
    }
    #endregion
}
