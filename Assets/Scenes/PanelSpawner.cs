using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpawner : MonoBehaviour
{
    public List<GameObject> panelList;

    public GameObject panelObj;

    private GameObject currentPanel;
    private int _panelListIteration = -1;

    public bool testAddPanel;

    public Transform panelParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testAddPanel)
        {
            testAddPanel = false;
            AddPanel();
        }
    }

    void AddPanel()
    {
        if (_panelListIteration == -1)
        {
            GameObject tempPanel = Instantiate(panelObj, Vector3.zero, Quaternion.identity);
            tempPanel.transform.SetParent(panelParent);
            var tempRectTrans = tempPanel.GetComponent<RectTransform>();
            tempRectTrans.SetBottom(-1060);
            tempRectTrans.SetTop(1060);
            tempRectTrans.SetRight(0);
            tempRectTrans.SetLeft(0);
        }

        _panelListIteration++;
    }
}
