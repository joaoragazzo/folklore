using UnityEngine;
using TMPro; // ou "using TMPro;" se estiver usando TextMesh Pro
using System.Collections;

public class ScreenSettingsController : MonoBehaviour
{
    public TMP_Dropdown screenDropdown; // ou "public TMP_Dropdown screenDropdown;" para TextMesh Pro

    void Start()
    {
        // Adicionar um ouvinte para quando a seleção mudar
        screenDropdown.onValueChanged.AddListener(delegate { OnScreenChange(); });
    }

    public void OnScreenChange()
    {
        Debug.Log(screenDropdown.value);
        
        switch (screenDropdown.value)
        {
            case 0: // Cheia
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            
            case 1: // Cheia Sem Bordas
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            
            case 2: // Janela
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            
            
        }
    }
}