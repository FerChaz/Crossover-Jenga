using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceClickHandler : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject infoCanvas;
    private PieceData _selectedPieceData;

    private void Start()
    {
        mainCamera = Camera.main;
        infoCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (_selectedPieceData != null)
                {
                    _selectedPieceData._isSelected = false;
                    _selectedPieceData = null;
                }
                _selectedPieceData = hit.collider.gameObject.GetComponent<PieceData>();
                if (_selectedPieceData != null)
                {
                    _selectedPieceData.ShowInfoCanvas();
                }
            }
            else
            {
                if (_selectedPieceData != null)
                {
                    _selectedPieceData._isSelected = false;
                    _selectedPieceData = null;
                }
                UIController.Instance.DeactivateDataPanel();
            }
        }
    }
}
