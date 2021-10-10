using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntenneDetection : MonoBehaviour
{

    public float nearDistance = 20.0f;
    public float averageDistance = 35.0f;
    public float farDistance = 50.0f;

    //The bigger the value is, the nearer it is
    private int distanceClue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] antennas = GameObject.FindGameObjectsWithTag("Antenne");
        float lowestDistance = float.PositiveInfinity;
        GameObject antennaSelected = null;
        foreach (GameObject antenna in antennas)
        {
            if (Mathf.Abs(antenna.transform.position.magnitude - transform.position.magnitude) < lowestDistance)
            {
                lowestDistance = antenna.transform.position.sqrMagnitude;
                antennaSelected = antenna;
            }
        }

        float distance = Mathf.Abs(antennaSelected.transform.position.magnitude - transform.position.magnitude);

        if (distance > nearDistance) { distanceClue = 0; }
        else if (distance < farDistance && distance > averageDistance) { distanceClue = 1; }
        else if (distance < averageDistance && distance > nearDistance) { distanceClue = 2; }
        else if (distance < nearDistance) { distanceClue = 3; }
    }

    public float GetDistanceClue()
    {
        return distanceClue;
    }
}
