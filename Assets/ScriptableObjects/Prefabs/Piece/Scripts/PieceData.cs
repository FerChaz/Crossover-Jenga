using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceData : MonoBehaviour
{
    private JengaPieceData _jengaPieceData;
    public bool _isSelected = false;
    private MeshRenderer _pieceMaterial;
    private Material _selectedMaterial;

    public JengaPieceData JengaPieceData
    {
        set => _jengaPieceData = value;
        get => _jengaPieceData;
    }

    private void Awake()
    {
        _pieceMaterial = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (_isSelected)
        {
            _pieceMaterial.material.color = Color.red;
        }
        else
        {
            _pieceMaterial.material.color = _jengaPieceData.Mastery == 0 ? new Color(0,0,0,0) : Color.white ;
        }
    }

    public void ShowInfoCanvas()
    {
        _isSelected = true;
        string grade = _jengaPieceData.GradeLevel + ":" + _jengaPieceData.Domain;
        string standard = _jengaPieceData.StandardID + ":" + _jengaPieceData.StandardDescription;
        UIController.Instance.ActivateDataPanel(grade, _jengaPieceData.Cluster, standard);
    }
}
