using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections.Generic;

public class ClientManager : MonoBehaviour
{
    public TextMeshProUGUI clientListText;
    public TMP_Dropdown filterDropdown;

    private const string apiUrl =
        "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";

    [SerializeField]
    ClientDataWrapper clientData;

    [SerializeField]
    ClientData client;

    [SerializeField]
    List<DataEntry> dataEntry;

    string clientList;
    string clientDataString;

    string dataEntryString;
    string dataList;

    private void Start()
    {
        StartCoroutine(LoadDataFromAPI());
    }

    private IEnumerator LoadDataFromAPI()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (
                webRequest.result == UnityWebRequest.Result.ConnectionError
                || webRequest.result == UnityWebRequest.Result.ProtocolError
            )
            {
                Debug.LogError("Error while fetching data from API: " + webRequest.error);
            }
            else
            {
                clientData = JsonUtility.FromJson<ClientDataWrapper>(
                    webRequest.downloadHandler.text
                );

                //dataList = JsonHelper.GetJsonObject(dataEntryString, "1");
                //dataEntry = JsonUtility.FromJson<DataEntry>(dataList);

                dataEntryString = JsonHelper.GetJsonObject(webRequest.downloadHandler.text, "data");

                for (int i = 1; i <= 3; i++)
                {
                    dataList = JsonHelper.GetJsonObject(dataEntryString, i.ToString());
                    Debug.Log(dataList);
                    dataEntry.Add(JsonUtility.FromJson<DataEntry>(dataList));
                }
            }
        }
    }
}
