using System.Collections.Generic;

[System.Serializable]
public class ClientData
{
    public bool isManager;
    public int id;
    public string label;
    public string name;
}

[System.Serializable]
public class DataEntry
{
    public string address;
    public string name;
    public int points;
}

[System.Serializable]
public class ClientDataWrapper
{
    public List<ClientData> clients;
    public string label;

    //public Dictionary<string, DataEntry> data;
}
