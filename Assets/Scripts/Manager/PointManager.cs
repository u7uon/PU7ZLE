using System;
using Unity.VisualScripting;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    //Singleton instance
    public static PointManager instance;

    public Action<int> OnPointChanged;
    private int points = 0;
    private const int LINECLEAR_POINT = 100; // Points awarded for clearing a line
    private const int BLOCKPLACE_POINT = 10; // Points awarded for dropping a block

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            OnLineCleared();
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            OnBlockPlaced();
        }
    }

    void OnBlockPlaced()
    {
         if(Timer.instance == null )
        {
           AddPoints(BLOCKPLACE_POINT);
            return;
        }
        if(Timer.instance.IsTimeUp() )
            return;

        int finalPoint = BLOCKPLACE_POINT + ( Mathf.FloorToInt(BLOCKPLACE_POINT * Timer.instance.GetBonusPointPercent()) );
        AddPoints(finalPoint);
    }

    void OnLineCleared()
    {
        if(Timer.instance == null )
        {
           AddPoints(LINECLEAR_POINT);
            return;
        }
        if(Timer.instance.IsTimeUp() )
            return;

        int finalPoint = LINECLEAR_POINT + ( Mathf.FloorToInt(LINECLEAR_POINT * Timer.instance.GetBonusPointPercent()) );
        // Increase points when a line is cleared
        AddPoints(finalPoint);
    }

    void AddPoints(int points)
    {
       this.points += points;
        OnPointChanged?.Invoke(this.points);
    }
}