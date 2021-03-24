using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    [Header("optional")]
    public GameObject turret;

    public Color hoverColor;
    public Color hoverCanBuildColor;
    public Color hoverCantBuildColor;
    private Color defaultColor;
    public Vector3 positionOffset;

    private Renderer rend;

    BuildManager buildManager;


    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
        buildManager = BuildManager.instance;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
        {
            rend.material.color = hoverColor;
            return;
        }

        if (buildManager.CanBuy)
            rend.material.color = hoverCanBuildColor;
        else rend.material.color = hoverCantBuildColor; 
    }

    private void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
}
