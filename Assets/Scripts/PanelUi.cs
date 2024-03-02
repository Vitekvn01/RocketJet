using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUi : MonoBehaviour
{
    [SerializeField] private GameObject PanelWin;
    [SerializeField] private GameObject PanelLose;

    private void Awake()
    {
        PanelWin.SetActive(false);
        PanelLose.SetActive(false);
    }
    public void ActivePanelWin()
    {
        PanelWin.SetActive(true);
    }
    public void ActivePanelLose()
    {
        PanelLose.SetActive(true);
    }
}
