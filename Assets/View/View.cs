using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    private Presenter _presenter;
    [SerializeField] private GameObject jengaPiece;
    [SerializeField] private GameObject jengaStack;
    [SerializeField] private int jengaPieces = 0;
    [SerializeField] private List<Material> materials;
    public float distanceBetweenObjectsOnYAxis = 1f;
    public float distanceBetweenStacks = 10f;
    private float currentYPosition = 0f;
    private float currentXPosition = 0f;
    private List<GameObject> _stacks = new List<GameObject>();
    private bool _isFirstStack = true;

    private void Start()
    {
        _presenter = new Presenter(view: this);
    }
    
    public void InstantiatePieces(List<DomainObject> dataObjects) 
    {
        string currentStack = "-1";
        int currentPieceIndex = 0;
        int currentAxisToMove = 0;
        Quaternion quaternion = Quaternion.identity;
        foreach (DomainObject dataObject in dataObjects)
        {
            if (!dataObject.grade.Contains("Grade")) continue;
            Vector3 position = Vector3.zero;
            if (dataObject.grade != currentStack)
            {
                currentStack = dataObject.grade;
                GameObject stackInstance = CreateStackInstance(currentStack);
                _stacks.Add(stackInstance);
                currentXPosition = (_stacks.Count - 1) * distanceBetweenStacks;
                currentYPosition = 0f;
                currentPieceIndex = 0;
                quaternion = Quaternion.identity;
                currentAxisToMove = 0;
                string gradeText = dataObject.grade.Replace(" Grade", string.Empty);
                UIController.Instance.AddGradeSelector(gradeText, currentXPosition, stackInstance.GetComponent<StackState>());
                Vector3 stackPosition = new Vector3(currentXPosition, 0 ,0);
                stackInstance.transform.position = stackPosition;
            }
            if (currentPieceIndex == 3)
            {
                currentPieceIndex = 0;
                currentYPosition += distanceBetweenObjectsOnYAxis;
                quaternion = RotateQuaternion(quaternion);
                currentAxisToMove = ToggleAxis(currentAxisToMove);
            }
            position = CalculatePiecePosition(currentPieceIndex, currentAxisToMove);
            position.y = currentYPosition;
            GameObject instance = CreateJengaPieceInstance(position, quaternion, dataObject.mastery);
            JengaPieceData jengaPieceData = CreateJengaPieceData(dataObject);
            instance.GetComponent<PieceData>().JengaPieceData = jengaPieceData;
            jengaPieces++;
            currentPieceIndex++;
        }
    }

    private GameObject CreateStackInstance(string currentStack)
    {
        GameObject stackInstance = Instantiate(jengaStack);
        stackInstance.name = "Stack " + currentStack;
        stackInstance.GetComponentInChildren<TextMeshProUGUI>().text = currentStack;
        if (_isFirstStack)
        {
            stackInstance.GetComponent<StackState>().IsSelected = true;
            _isFirstStack = false;
        }
        return stackInstance;
    }

    private Quaternion RotateQuaternion(Quaternion quaternion)
    {
        return quaternion * Quaternion.Euler(0, 90, 0);
    }

    private int ToggleAxis(int currentAxisToMove)
    {
        return currentAxisToMove == 0 ? 2 : 0;
    }

    private Vector3 CalculatePiecePosition(int currentPieceIndex, int currentAxisToMove)
    {
        Vector3 position = Vector3.zero;
        switch (currentPieceIndex)
        {
            case 0:
                position[currentAxisToMove] = -1.05f;
                break;
            case 1:
                position[currentAxisToMove] = 0;
                break;
            case 2:
                position[currentAxisToMove] = 1.05f;
                break;
        }
        return position;
    }

    private GameObject CreateJengaPieceInstance(Vector3 position, Quaternion quaternion, int mastery)
    {
        GameObject instance = Instantiate(jengaPiece, _stacks[^1].transform, false);
        instance.transform.localPosition = position;
        instance.transform.rotation = quaternion;
        instance.GetComponent<MeshRenderer>().material = materials[mastery];
        return instance;
    }

    private JengaPieceData CreateJengaPieceData(DomainObject dataObject)
    {
        JengaPieceData jengaPieceData = ScriptableObject.CreateInstance<JengaPieceData>();
        jengaPieceData.Cluster = dataObject.cluster;
        jengaPieceData.Domain = dataObject.domain;
        jengaPieceData.GradeLevel = dataObject.grade;
        jengaPieceData.StandardDescription = dataObject.standarddescription;
        jengaPieceData.StandardID = dataObject.standardid;
        jengaPieceData.Mastery = dataObject.mastery;
        return jengaPieceData;
    }
}
