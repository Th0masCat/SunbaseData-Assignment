using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModalManager : MonoBehaviour
{
    [SerializeField]
    GameObject modalGameObject;

    [Header("Modal Text")]
    [SerializeField]
    TextMeshProUGUI clientName;

    [SerializeField]
    TextMeshProUGUI clientPoints;

    [SerializeField]
    TextMeshProUGUI clientAddress;

    public static ModalManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OpenModal()
    {
        modalGameObject.SetActive(true);
    }

    public void CloseModal()
    {
        modalGameObject.SetActive(false);
    }

    public void SetModalData(string name, string points, string address)
    {
        clientName.text = name;
        clientPoints.text = points;
        clientAddress.text = address;
    }
}
