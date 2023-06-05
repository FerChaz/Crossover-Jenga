using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _uiSelectPanel;
    [SerializeField] private GameObject _uiDataPanel;
    [SerializeField] private GameObject _selectorPrefab;
    [SerializeField] private Camera _mainCamera;
    
    public static UIController Instance;
    private void Awake()
    {
        Instance = this;
        _mainCamera = Camera.main;
    }

    public void AddGradeSelector(string grade, float xPosition, StackState stackSelectedState)
    {
        GameObject instance = Instantiate(_selectorPrefab, _uiSelectPanel.transform, true);
        instance.GetComponentInChildren<TextMeshProUGUI>().text = grade;
        instance.GetComponent<Button>().onClick.AddListener(() => SelectGrade(xPosition, stackSelectedState));
    }

    public void SelectGrade(float xPositionToMoveTo, StackState stackSelectedState)
    {
        StackState selectedObject = FindObjectsOfType<StackState>()
            .FirstOrDefault(obj => obj.IsSelected);
        selectedObject.IsSelected = false;
        
        stackSelectedState.IsSelected = true;
        var cameraTransform = _mainCamera.transform;
        Vector3 position = CameraController.Instance.cameraDefaultPosition;
        position.x = xPositionToMoveTo;
        cameraTransform.position = position;
        CameraController.Instance.SetTarget(xPositionToMoveTo);
        cameraTransform.LookAt(CameraController.Instance.transform);
    }

    public void ActivateDataPanel(string grade, string cluster, string standard)
    {
        _uiDataPanel.SetActive(true);
        _uiDataPanel.GetComponent<DataPanelController>().SetPanelInfo(grade, cluster, standard);
    }

    public void DeactivateDataPanel()
    {
        if (_uiDataPanel.activeSelf) _uiDataPanel.SetActive(false);
    }
}
