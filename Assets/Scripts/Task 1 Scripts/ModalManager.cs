using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ModalManager : MonoBehaviour
{
    [SerializeField]
    GameObject modalGameObject;

    [SerializeField]
    GameObject list;

    [SerializeField]
    GameObject dropdown;

    [Header("Modal Text")]
    [SerializeField]
    TextMeshProUGUI clientName;

    [SerializeField]
    TextMeshProUGUI clientPoints;

    [SerializeField]
    TextMeshProUGUI clientAddress;

    [SerializeField]
    TextMeshProUGUI clientLabel;

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
        modalGameObject.gameObject.SetActive(true);
        list.GetComponent<RectTransform>().DOAnchorPosY(-500f, 0.5f);
        modalGameObject.transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosY(0f, 0.5f);
        clientLabel.GetComponent<RectTransform>().DOAnchorPosY(0f, 0.5f);
        dropdown.GetComponent<RectTransform>().DOAnchorPosY(100f, 0.5f);
    }

    public void CloseModal()
    {
        modalGameObject.transform
            .GetChild(0)
            .GetComponent<RectTransform>()
            .DOAnchorPosY(-500f, 0.5f)
            .OnComplete(() => modalGameObject.gameObject.SetActive(false));
        list.GetComponent<RectTransform>().DOAnchorPosY(0f, 0.5f);
        clientLabel.GetComponent<RectTransform>().DOAnchorPosY(-500f, 0.5f);
        dropdown.GetComponent<RectTransform>().DOAnchorPosY(-31.75f, 0.5f);
    }

    public void SetModalData(string name, string points, string address, string label)
    {
        clientName.text = name;
        clientPoints.text = points;
        clientAddress.text = address;
        clientLabel.text = label;
    }
}
