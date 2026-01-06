using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField ] private Sprite normal ; 
    [SerializeField ] private Sprite hightLight ; 

    private SpriteRenderer _re ; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _re = GetComponent<SpriteRenderer>() ; 
        //Normal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Normal()
    {
        gameObject.SetActive(true);
        _re.color = Color.white;
        _re.sprite = normal ; 
    }
    public void HightLight()
    {
        gameObject.SetActive(true);
        _re.color = Color.white;
        _re.sprite = hightLight ; 
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Hover()
    {
        gameObject.SetActive(true);
        _re.color = new(1f,1f,1f,0.5f);
        _re.sprite = normal ; 
    }
}
