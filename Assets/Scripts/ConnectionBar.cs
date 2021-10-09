using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionBar : MonoBehaviour
{
    public Slider slider;
    public void setMaxConnection(int Connection)
    {
        slider = GetComponent<Slider>();
        slider.maxValue = Connection;
        slider.value = Connection;
    }
    public void SetConnection (int Connection)
    {
        slider.value = Connection;
    }
}
