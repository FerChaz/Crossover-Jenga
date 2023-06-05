using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataPanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _grade;
    [SerializeField] private TextMeshProUGUI _cluster;
    [SerializeField] private TextMeshProUGUI _standard;

    public void SetPanelInfo(string grade, string cluster, string standard)
    {
        _grade.text = grade;
        _cluster.text = cluster;
        _standard.text = standard;
    }
}
