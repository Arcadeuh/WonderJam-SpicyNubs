using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AntennaCount : MonoBehaviour
{

    private List<GameObject> antennas;
    private bool flag = false;

    public Text textUI;
    public UnityEvent onAntennasRepaired;

    // Start is called before the first frame update
    void Start()
    {
        antennas = new List<GameObject>(GameObject.FindGameObjectsWithTag("Antenna"));
    }

    // Update is called once per frame
    void Update()
    {
        if (flag) return;

        if (antennas.Count == 0 && !flag)
        {
            onAntennasRepaired.Invoke();
            flag = true;
            textUI.text = "0";
            return;
        }

        foreach (GameObject antenna in antennas)
        {
            if (antenna.GetComponent<BrokenAntena>().GetIsRepaired())
            {
                antennas.Remove(antenna);
            }
        }
        textUI.text = antennas.Count.ToString();
    }
}
