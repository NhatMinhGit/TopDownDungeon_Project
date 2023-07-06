using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMenuController : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene("Village");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

