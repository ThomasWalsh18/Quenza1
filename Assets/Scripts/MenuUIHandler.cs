using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;
    }

    //This code will be for changing between the main menu scene and the application scene
    public void ApplicationScene()
    {
        //Using the inbuilt scene manager
        SceneManager.LoadScene(1);
    }

    //Code to quit the application
    public void Quit()
    {
        MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        //Adding this code so the quit button also stops the application from playing when in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //This will be attached to the exit button and will close the application
        Application.Quit();
#endif
    }

    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
}
