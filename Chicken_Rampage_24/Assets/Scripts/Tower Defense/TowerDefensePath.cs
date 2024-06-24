using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefensePath : MonoBehaviour
{

    [SerializeField] private List<Transform> pathNodes;

    public static TowerDefensePath towerDefensePath;

    // Start is called before the first frame update
    void Start()
    {
        towerDefensePath = this;
    }

    public List<Transform> getPath()
    {
        return pathNodes;
    }
}
