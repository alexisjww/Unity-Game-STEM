/*
Author: Max
Date Created: July 11, 2020
Purpose: To load scenes/levels 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Include scene loading package

public class LoadSceneOnClick : MonoBehaviour
{
    public string targetScene; //This is the name of the scene that gets loaded when function is triggered

    //This function will load the target scene
    public void loadScene() //<- Function
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single); //Tells computer to load scene/level
    }
}
