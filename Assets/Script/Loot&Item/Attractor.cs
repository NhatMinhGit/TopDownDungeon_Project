using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attractor : MonoBehaviour
{

    public TextMeshProUGUI dropText;
    public float AttractorSpeed;
    public float _dropCount;
   // public Inventory inventory;

    private void Start()
    {
       // _dropCount = inventory.dropCount;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, collision.transform.position, AttractorSpeed * Time.deltaTime);
            
            Destroy(gameObject, 0.5f);
            
        }
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // AddItemPoint();
    }
    /*
    private void AddItemPoint()
    {
        _dropCount = PlayerPrefs.GetFloat("drop", 0); //khai báo một biến có thể lưu trữ và có giá trị mặc định = 0 (và được lưu trữ dưới dạng tag name)
        _dropCount +=1;
        PlayerPrefs.SetFloat("drop", _dropCount);
        dropText.text = Mathf.FloorToInt(_dropCount).ToString("D1");

    }*/
   
}
