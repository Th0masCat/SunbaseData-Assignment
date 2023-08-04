using System.Collections.Generic;

// Represents individual client data
[System.Serializable]
public class ClientData
{
    public bool isManager;
    public int id;
    public string label;
    public string name;
}

// Represents a single data entry
[System.Serializable]
public class DataEntry
{
    public string address;
    public string name;
    public int points;
}


// Represents a collection of client data
// TO deserialize data I have used JsonHelper.cs
[System.Serializable]
public class ClientDataWrapper
{
    public List<ClientData> clients;
    public string label;

    //public Dictionary<string, DataEntry> data;
}
