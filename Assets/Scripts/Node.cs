using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {

    private Renderer rend;
    public Color hovorColor;
    private Color startColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    BuildManager buildManager;
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;   
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
            return;
        
        if (turret != null)
        {
            Debug.Log("Cannot build here - TODO: display on screen");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hovorColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }

            
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;    
    }
}
