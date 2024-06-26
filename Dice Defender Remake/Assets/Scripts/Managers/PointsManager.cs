using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    public int points {  get; private set; }



    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance );
            return;
        }

        instance = this;
    }

    public static PointsManager GetInstance()
    {
           return instance;
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }
}
