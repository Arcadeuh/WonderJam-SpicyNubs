using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings_menu : MonoBehaviour
{
    public void SetQualityLevel(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
