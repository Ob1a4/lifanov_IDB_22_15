using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Task_2 : MonoBehaviour
{   
    public TMP_Text textcounter;
    private int counter = 100;
    private Vector3 xStep = new Vector3(1, 0, 0);
    private Vector3 zStep = new Vector3(0, 0, 1);
    private Vector3 yStep = new Vector3(0, 5, 0);

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Plane" && (counter != 0))
        {
            textcounter.text = "HP: " + System.Convert.ToString(counter - 10);
            counter -= 10;
        }
        else if (collision.gameObject.name == "Cube2")
        {
            collision.gameObject.SetActive(false);
            textcounter.text = "Enemy is dead";
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            transform.position -= zStep;
        }
        if (Input.GetKeyDown("left"))
        {
            transform.position += zStep;
        }
        if (Input.GetKeyDown("up"))
        {
            transform.position += xStep;
        }
        if (Input.GetKeyDown("down"))
        {
            transform.position -= xStep;
        }
        if (Input.GetKeyDown("space"))
        {
            transform.position += yStep;
        }
    }
}
