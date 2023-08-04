using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ClientManager : MonoBehaviour
{
    public TextMeshProUGUI clientListText;
    public TMP_Dropdown filterDropdown;

    private const string apiUrl =
        "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";

    [SerializeField]
    ClientDataWrapper clientData;

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
                // Call a method to populate the UI with the data.
                PopulateClientList();
            }
        }
    }

    private void PopulateClientList()
    {
        if (clientData.data.ContainsKey("1"))
            clientListText.text = clientData.data["1"].name;
    }
}
