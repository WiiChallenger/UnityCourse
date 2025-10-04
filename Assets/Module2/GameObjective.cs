using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjective : MonoBehaviour
{
    public string sceneName = "Level_1";
    public int gamesComplete = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CompletionTracker();
        }
    }

    public void CompletionTracker()
    {
        // adds a key then gets the key adds it sets it then saves... 
        string key = "Level_Complete"; 
        gamesComplete = PlayerPrefs.GetInt(key, gamesComplete);
        gamesComplete += 1;
        PlayerPrefs.SetInt(key, gamesComplete);
        PlayerPrefs.Save();
        //Debug.Log("Level complete" + gamesComplete);

        if (gamesComplete > 2)
        {
            //returns the value to zero and owns the player :)
            //Debug.Log("Loading gag..");
            gamesComplete = 0;
            PlayerPrefs.SetInt(key, gamesComplete);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level_-0");
            
        }
        else
        {
            SceneManager.LoadScene("Level_1");
        }
    }
}
