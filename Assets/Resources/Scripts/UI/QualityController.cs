
using UnityEngine;
using TMPro;
public class QualityController : MonoBehaviour
{
    public TMP_Dropdown qualityDropdown;
    
    void Start()
    {
        InitializeQualityDropdown();
    }

    void InitializeQualityDropdown()
    {
        qualityDropdown.ClearOptions();
        
        // Adicionar as opções de qualidade ao Dropdown
        foreach (var name in QualitySettings.names)
        {
            qualityDropdown.options.Add(new TMP_Dropdown.OptionData(name));
        }

        // Define a seleção atual para a configuração atual de qualidade
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();

        // Adicionar um ouvinte para quando a seleção mudar
        qualityDropdown.onValueChanged.AddListener(delegate { OnQualityChange(); });
    }
    
    public void OnQualityChange()
    {
        QualitySettings.SetQualityLevel(qualityDropdown.value, true);
    }
    
    
    
    
}