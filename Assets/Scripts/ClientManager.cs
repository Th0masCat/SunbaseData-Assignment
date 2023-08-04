using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    public TextMeshProUGUI clientListText;
    public TMP_Dropdown filterDropdown;

    [SerializeField]
    GameObject clientDetailsPrefab;

    [SerializeField]
    Transform clientDetailsParent;

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

                UpdateClientList();
            }
        }
    }

    void UpdateClientList()
    {
        Dictionary<string, string> clientInfo = new();

        for (int i = 0; i < 3; i++)
        {
            clientInfo.Add(clientData.clients[i].label, dataEntry[i].points.ToString());
        }

        foreach (KeyValuePair<string, string> client in clientInfo)
        {
            GameObject newItem = Instantiate(clientDetailsPrefab, clientDetailsParent);
            newItem
                .GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    ModalManager.Instance.SetModalData(
                        dataEntry[clientData.clients.FindIndex(x => x.label == client.Key)].name,
                        dataEntry[
                            clientData.clients.FindIndex(x => x.label == client.Key)
                        ].points.ToString(),
                        dataEntry[clientData.clients.FindIndex(x => x.label == client.Key)].address
                    );
                    ModalManager.Instance.OpenModal();
                });

            newItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = client.Key;
            newItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = client.Value;
        }
    }
}
