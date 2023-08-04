using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    // Enum to define different client filters
    public enum ClientFilter
    {
        All,
        Manager,
        NonManager
    }

    private ClientFilter currentFilter = ClientFilter.All;

    private const string apiUrl =
        "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";

    [SerializeField]
    GameObject clientDetailsPrefab; // Prefab for displaying client details

    [SerializeField]
    Transform clientDetailsParent; // Parent transform to hold client details

    ClientDataWrapper clientData; // Class holding client data from the API
    List<DataEntry> dataEntry; // List holding data entries from the API

    string dataEntryString;
    string dataList;

    //I could only see 3 entries valid in the API response, so I have hardcoded the list length to 3
    private int listLength = 3;

    private void Start()
    {
        StartCoroutine(LoadDataFromAPI()); // Start the coroutine to fetch data from the API
    }

    private IEnumerator LoadDataFromAPI()
    {
        // Sending a GET request to the API and waiting for the response
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            // Check for errors in the API response
            if (
                webRequest.result == UnityWebRequest.Result.ConnectionError
                || webRequest.result == UnityWebRequest.Result.ProtocolError
            )
            {
                Debug.LogError("Error while fetching data from API: " + webRequest.error);
            }
            else
            {
                // Deserialize the JSON response into the clientData object
                clientData = JsonUtility.FromJson<ClientDataWrapper>(
                    webRequest.downloadHandler.text
                );

                // Extracting the "data" field from the JSON response
                dataEntryString = JsonHelper.GetJsonObject(webRequest.downloadHandler.text, "data");

                // Parsing individual data entries from the "data" field and adding them to the dataEntry list
                for (int i = 1; i <= listLength; i++)
                {
                    dataList = JsonHelper.GetJsonObject(dataEntryString, i.ToString());
                    Debug.Log(dataList);
                    dataEntry.Add(JsonUtility.FromJson<DataEntry>(dataList));
                }

                // Update the client list display with the fetched data
                UpdateClientList();
            }
        }
    }

    // Method to update the client list display based on the current filter
    void UpdateClientList()
    {
        // Clear the existing client details in the clientDetailsParent
        foreach (Transform child in clientDetailsParent)
        {
            Destroy(child.gameObject);
        }

        // Dictionary to hold client information (label and points)
        Dictionary<string, string> clientInfo = new();

        // Loop through the data entries and add relevant client information based on the current filter
        for (int i = 0; i < listLength; i++)
        {
            switch (currentFilter)
            {
                case ClientFilter.All:
                    clientInfo.Add(clientData.clients[i].label, dataEntry[i].points.ToString());
                    break;
                case ClientFilter.Manager:
                    if (clientData.clients[i].isManager)
                    {
                        clientInfo.Add(clientData.clients[i].label, dataEntry[i].points.ToString());
                    }
                    break;
                case ClientFilter.NonManager:
                    if (!clientData.clients[i].isManager)
                    {
                        clientInfo.Add(clientData.clients[i].label, dataEntry[i].points.ToString());
                    }
                    break;
            }
        }

        // Create UI elements for each client and populate them with the relevant data
        foreach (KeyValuePair<string, string> client in clientInfo)
        {
            GameObject newItem = Instantiate(clientDetailsPrefab, clientDetailsParent);
            newItem
                .GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    // When a client is clicked, update and open the modal with relevant details
                    ModalManager.Instance.SetModalData(
                        dataEntry[clientData.clients.FindIndex(x => x.label == client.Key)].name,
                        dataEntry[
                            clientData.clients.FindIndex(x => x.label == client.Key)
                        ].points.ToString(),
                        dataEntry[clientData.clients.FindIndex(x => x.label == client.Key)].address,
                        client.Key
                    );
                    ModalManager.Instance.OpenModal();
                });

            newItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = client.Key; // Set client label
            newItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = client.Value; // Set client points
        }
    }

    // Method to handle changes in the filter dropdown
    public void OnFilterDropdownValueChanged(int index)
    {
        currentFilter = (ClientFilter)index; // Update the current filter based on the dropdown selection

        UpdateClientList(); // Update the client list display based on the new filter
    }
}
