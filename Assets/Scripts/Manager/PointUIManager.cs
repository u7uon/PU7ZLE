using TMPro;
using UnityEngine;

public class PointUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText; // Reference to the UI Text element displaying the point value
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PointManager.instance.OnPointChanged += OnPointChanged;
        if(pointText != null)
        {
            pointText.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnPointChanged(int newPoint)
    {
        if (pointText != null)
        {
            pointText.text = newPoint.ToString();
        }
    }
}
