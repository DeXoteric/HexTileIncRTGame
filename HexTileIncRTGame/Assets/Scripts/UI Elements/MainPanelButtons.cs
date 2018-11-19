using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelButtons : MonoBehaviour {

    [SerializeField] GameObject hqPanel;
    [SerializeField] GameObject resourcePanel;
    [SerializeField] GameObject productionPanel;

    private void OnEnable()
    {
        OpenHqPanel();
    }

    public void OpenHqPanel()
    {
        hqPanel.SetActive(true);
        resourcePanel.SetActive(false);
        productionPanel.SetActive(false);
    }

    public void OpenResourcePanel()
    {
        hqPanel.SetActive(false);
        resourcePanel.SetActive(true);
        productionPanel.SetActive(false);
    }

    public void OpenProductionPanel()
    {
        hqPanel.SetActive(false);
        resourcePanel.SetActive(false);
        productionPanel.SetActive(true);
    }
}
