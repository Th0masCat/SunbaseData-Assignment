using UnityEngine;
using TMPro;
using DG.Tweening;

public class ModalManager : MonoBehaviour
{
    // Modal GameObject
    [Header("Modal GameObject")]
    [SerializeField]
    private GameObject modalGameObject;

    // Main Screen RectTransforms
    [Header("Main Screen RectTransforms")]
    [SerializeField]
    private RectTransform modalWindowRectTransform;

    [SerializeField]
    private RectTransform listRectTransform;

    [SerializeField]
    private RectTransform dropdownRectTransform;

    // Modal Text
    [Header("Modal Text")]
    [SerializeField]
    private TextMeshProUGUI clientName;

    [SerializeField]
    private TextMeshProUGUI clientPoints;

    [SerializeField]
    private TextMeshProUGUI clientAddress;

    [SerializeField]
    private TextMeshProUGUI clientLabel;

    public static ModalManager Instance;

    private void Awake()
    {
        // Ensure there is only one instance of ModalManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this duplicate
            return;
        }
    }

    // Open the modal window
    public void OpenModal()
    {
        modalGameObject.SetActive(true);

        // Animate the list and other elements to create the modal effect
        listRectTransform.DOAnchorPosY(-500f, 0.5f);
        modalWindowRectTransform.DOAnchorPosY(0f, 0.5f);
        clientLabel.GetComponent<RectTransform>().DOAnchorPosY(0f, 0.5f);
        dropdownRectTransform.DOAnchorPosY(100f, 0.5f);
    }

    // Close the modal window
    public void CloseModal()
    {
        // Animate the modal elements to close the modal window
        modalWindowRectTransform
            .DOAnchorPosY(-500f, 0.5f)
            .OnComplete(() => modalGameObject.SetActive(false));

        listRectTransform.GetComponent<RectTransform>().DOAnchorPosY(0f, 0.5f);
        clientLabel.GetComponent<RectTransform>().DOAnchorPosY(-500f, 0.5f);
        dropdownRectTransform.GetComponent<RectTransform>().DOAnchorPosY(-31.75f, 0.5f);
    }

    // Set the data to be displayed in the modal
    public void SetModalData(string name, string points, string address, string label)
    {
        clientName.text = name;
        clientPoints.text = points;
        clientAddress.text = address;
        clientLabel.text = label;
    }
}
