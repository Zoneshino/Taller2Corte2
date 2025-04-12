using UnityEngine;
using UnityEngine.UI;

public class LifeUIConnector : MonoBehaviour
{
    public Image[] heartIcons;

    void Start()
    {
        if (LifeSystem.instance != null)
        {
            LifeSystem.instance.AssignHeartUI(heartIcons);
        }
        else
        {
            Debug.LogWarning("No se encontró LifeSystem para asignar UI.");
        }
    }
}