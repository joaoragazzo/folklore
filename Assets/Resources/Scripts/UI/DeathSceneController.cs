
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneController : MonoBehaviour
{
    public Button goBackToMenu;
    public Button repeatGame;

    public void Start()
    {
        goBackToMenu.onClick.AddListener(goBackToMenuFunction);
        repeatGame.onClick.AddListener(repeatGameFunction);
    }

    public void goBackToMenuFunction()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void repeatGameFunction()
    {
        SceneManager.LoadScene("MainGame");
    }
}