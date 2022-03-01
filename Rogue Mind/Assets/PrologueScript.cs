using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        StartCoroutine(Animations());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Animations()
	{
        transform.GetChild(0).gameObject.active = true;
        yield return new WaitForSeconds(2);
        for (int i = 1; i < 7; i++)
		{
            transform.GetChild(i-1).gameObject.active = false;
            transform.GetChild(i).gameObject.active = true;
            yield return new WaitForSeconds(2);
        }
        SceneManager.LoadScene(2);
	}
}
