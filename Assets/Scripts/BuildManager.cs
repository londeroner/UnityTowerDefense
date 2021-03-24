using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{    
    public static BuildManager instance;
    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool CanBuy { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public Color defaultTextColor;
    public Color defaultShadowColor;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        node.turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);

        GameObject effectsIns = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effectsIns, 5f);
    }

}
