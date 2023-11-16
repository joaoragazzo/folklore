
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPrefab;
    public bool actualStateMenu;
    public Button goBackToMenu;


    public void Start()
    {
        goBackToMenu.onClick.AddListener(goBackToMenuFunc);
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            actualStateMenu = !actualStateMenu;            
            menuPrefab.SetActive(actualStateMenu);

            if (actualStateMenu)
            {
                WorldStatsController.Stats.Pause();
            }
            else
            {
                WorldStatsController.Stats.Unpause();
            }
        }
    }

    public void goBackToMenuFunc()
    {
        SceneManager.LoadScene("MainMenu");
    }
}