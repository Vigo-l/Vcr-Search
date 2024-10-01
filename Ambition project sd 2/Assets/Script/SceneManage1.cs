using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage1 : MonoBehaviour
{

    [SerializeField] private float VideoTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(VideoTime);
        SceneManager.LoadScene("SampleScene");
    }
}
