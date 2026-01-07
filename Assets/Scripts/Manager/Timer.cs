using UnityEngine.UI;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    //Singleton instance
    public static Timer instance;

    [SerializeField] Image timeGauge; // Reference to the UI Image representing the time gauge
    public static Action OnTimeUp; // Action to notify when time is up
    private const float TIME_LIMIT = 30.0f; // Time limit in seconds
    private float timeRemaining ; 
    private float elapsedTime = 0.0f; // Elapsed time in seconds
        private bool isLockupPlaying = false ;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elapsedTime = 0.0f;
        timeRemaining = TIME_LIMIT;
        //AudioManager.Instance.PlayeLoopSFX("TIMER");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            OnNewStage();
        }


        elapsedTime += Time.deltaTime;
        timeRemaining = TIME_LIMIT - elapsedTime;

        // Update the time gauge fill amount
        if (timeGauge != null)
        {
            timeGauge.fillAmount = timeRemaining / TIME_LIMIT;
        }

        if(timeRemaining < 10 && !isLockupPlaying)
        {
            AudioManager.Instance.StopLoopSFX();
            AudioManager.Instance.PlayeLoopSFX("CLOCKUP");
            isLockupPlaying = true ;
        }

        // Check if time has run out
        if (timeRemaining <= 0)
        {
            AudioManager.Instance.StopLoopSFX();
            OnTimeUp?.Invoke();
        }
    }

    void OnNewStage()
    {
        elapsedTime = 0.0f;
        timeRemaining = TIME_LIMIT;
        isLockupPlaying = false ;
        AudioManager.Instance.StopLoopSFX();
    }

    public float GetBonusPointPercent()
    {
        return timeRemaining/TIME_LIMIT;
    }

    public bool IsTimeUp()
    {
        return timeRemaining <= 0;
    }





    


}
