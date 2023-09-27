using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Object;

    public void Deactive()
    {
        Object.SetActive(!Object.activeInHierarchy);
    }
}
