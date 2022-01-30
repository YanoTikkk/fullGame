using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Screen = UnityEngine.Device.Screen;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuButtom;
    [SerializeField] private GameObject uiMenu;
    [SerializeField] private MonoBehaviour[] componentsToDisaple;

    
    public void OpenMenuWindow()
    {
        menuButtom.SetActive(false);
        uiMenu.SetActive(true);
        
        foreach (var VARIABLE in componentsToDisaple)
        {
            VARIABLE.enabled = false;
        }

        Time.timeScale = 0.01f;
    }
    
    public void CloseMenuWindow()
    {
        menuButtom.SetActive(true);
        uiMenu.SetActive(false);
        
        foreach (var VARIABLE in componentsToDisaple)
        {
            VARIABLE.enabled = true;
        }

        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
