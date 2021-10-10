using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntenneDetection : MonoBehaviour
{

    public float nearDistance = 20.0f;
    public float averageDistance = 35.0f;
    public float farDistance = 50.0f;
    public Animator animatorDetector;

    //The bigger the value is, the nearer it is
    private int distanceClue = 0;
    private GameObject[] antennas;

    // Start is called before the first frame update
    void Start()
    {
        antennas = GameObject.FindGameObjectsWithTag("Antenna");
    }

    // Update is called once per frame
    void Update()
    {
        float lowestDistance = float.PositiveInfinity;
        GameObject antennaSelected = null;
        foreach (GameObject antenna in antennas)
        {
            if (!antenna.GetComponent<BrokenAntena>().GetIsRepaired())
            {
                float distanceTemp = Mathf.Abs(Vector2.Distance(antenna.transform.position, transform.position));
                if (distanceTemp < lowestDistance)
                {
                    lowestDistance = distanceTemp;
                    antennaSelected = antenna;
                }
            }
        }

        if (!antennaSelected) { return; }

        float distance = Mathf.Abs(Vector2.Distance(antennaSelected.transform.position, transform.position));
        //Debug.Log(antennaSelected.name);
        //Debug.Log(distance);

        if (distance > farDistance) { distanceClue = 0; }
        else if (distance < farDistance && distance > averageDistance) { distanceClue = 1; }
        else if (distance < averageDistance && distance > nearDistance) { distanceClue = 2; }
        else if (distance < nearDistance) { distanceClue = 3; }
        animatorDetector.SetInteger("distanceClue", distanceClue);
    }

    public float GetDistanceClue()
    {
        return distanceClue;
    }
}
