using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHelper : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    public void RandStats()
    {
        gm.RandomlyChangeStats();
    }
}
