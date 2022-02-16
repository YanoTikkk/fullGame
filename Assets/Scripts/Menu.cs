using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuButtom;
    [SerializeField] private GameObject uiMenu;
    [SerializeField] private MonoBehaviour[] componentsToDisaple;

    
    public void OpenMenuWindow()
    {
        menuButtom.SetActive(false);
        uiMenu.SetActive(true);
        
        foreach (var variable in componentsToDisaple)
        {
            variable.enabled = false;
        }

        Time.timeScale = 0.01f;
    }
    
    public void CloseMenuWindow()
    {
        menuButtom.SetActive(true);
        uiMenu.SetActive(false);
        
        foreach (var variable in componentsToDisaple)
        {
            variable.enabled = true;
        }

        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
