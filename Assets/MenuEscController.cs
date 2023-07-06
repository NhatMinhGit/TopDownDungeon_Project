using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEscController : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(true);
        }
        
    }

    public void Exit()
    {
        SceneManager.LoadScene("Village");//Khi nhấn vào sẽ load scene village
    }
}
