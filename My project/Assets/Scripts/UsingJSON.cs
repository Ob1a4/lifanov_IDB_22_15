using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UsingJSON : MonoBehaviour
{
    public TextMeshPro firstName;
    public TextMeshPro lastName;
    public TextMeshPro post;
    public TextMeshPro phoneNumber;
    public string jsonURL;
    public Jsonclass jsnData;
    void Start()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        Debug.Log("Download...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        uwr.downloadHandler = dh;
        dh.removeFileOnAbort = true;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            firstName.text = "ERROR";
        }
        else
        {
            Debug.Log("Download saved to: " + resultFile);
            jsnData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            firstName.text = "Имя: " + jsnData.firstname.ToString();
            lastName.text = "Фамилия: " + jsnData.lastname.ToString();
            post.text = "Должность: " + jsnData.post.ToString();
            phoneNumber.text = "Телефон: " + jsnData.phonenumber.ToString();
            yield return StartCoroutine(getData());
        }
    }
    [System.Serializable]
    public class Jsonclass
    {
        public string firstname;
        public string lastname;
        public string post;
        public string phonenumber;
    }
}
