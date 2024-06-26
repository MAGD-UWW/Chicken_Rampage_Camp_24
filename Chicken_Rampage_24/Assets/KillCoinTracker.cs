using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCoinTracker : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int killCoinCount = 0;


    public void AddCoin()
    {
        killCoinCount++;
        GetComponent<TextMeshProUGUI>().text = killCoinCount.ToString();
    }

    public void RemoveCoin()
    {
        killCoinCount--;
        GetComponent<TextMeshProUGUI>().text = killCoinCount.ToString();
    }
}
