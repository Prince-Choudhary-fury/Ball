using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCotroller : MonoBehaviour
{
    
    public AudioSource win;
    public GameObject gameWinPanal;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.gameObject.tag == "Finish")
        {
            Destroy(other.gameObject);
            StartCoroutine(WinLoader());
        }
    }

    IEnumerator WinLoader()
    {
        UIManager.index = SceneManager.GetActiveScene().buildIndex;
        win.Play();
        gameWinPanal.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(4);
    }

}
