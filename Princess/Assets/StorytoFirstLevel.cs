using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StorytoFirstLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadFirstLevelNow()
    {
        
            Debug.Log("next scne");
            SceneManager.LoadScene("Level One");

        
    }
}
