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
        infoCanvas.SetActive(false); // Asegúrate de desactivar el canvas al inicio
    }

    private void Update()
    {
        // Verificar si se hizo clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            // Lanzar un rayo desde la posición del ratón en la pantalla
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verificar si el rayo golpea un objeto con colisionador
            if (Physics.Raycast(ray, out hit))
            {
                if (_selectedPieceData != null)
                {
                    _selectedPieceData._isSelected = false;
                    _selectedPieceData = null;
                }
                // Obtener el componente ObjectInfo del objeto clicado
                _selectedPieceData = hit.collider.gameObject.GetComponent<PieceData>();

                // Verificar si el objeto clicado tiene el componente ObjectInfo adjunto
                if (_selectedPieceData != null)
                {
                    // Mostrar la información en el canvas
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
