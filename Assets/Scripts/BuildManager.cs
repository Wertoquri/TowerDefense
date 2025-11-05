using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    [SerializeField] Color startColor;
    GameObject tempObj;
    [SerializeField] GameObject[] turrets;

    Ray ray;
    RaycastHit hit;
    private  bool  canBuild = false;
    private int turretIndex, cost;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Node"))
            {
                if (tempObj != null && !Equals(hit.collider.gameObject, tempObj))
                {
                    tempObj.GetComponent<MeshRenderer>().material.color = startColor;
                }
                tempObj = hit.collider.gameObject;
                tempObj.GetComponent<MeshRenderer>().material.color = hoverColor;
                if(Input.GetMouseButtonDown(0) && canBuild)
                {
                    tempObj.GetComponent<NodeBuildSetting>().StartBuild(turrets, turretIndex, 0.35f, cost);
                    FindObjectOfType<InterstitialAd>().TowerBuild();
                    canBuild = false;
                }
            }
            else
            {
                if (tempObj != null) tempObj.GetComponent<MeshRenderer>().material.color = startColor;
            }
        }
        else
        {
            if (tempObj != null)
            {
                tempObj.GetComponent<MeshRenderer>().material.color = startColor;
                tempObj = null;
            }
        }
    }

    public void SetBuildTurret(int buildCost, int buildIndex)
    {
        cost = buildCost;
        turretIndex = buildIndex;
        canBuild = true;
    }
}