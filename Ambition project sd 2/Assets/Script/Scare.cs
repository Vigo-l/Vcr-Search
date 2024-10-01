using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scare : MonoBehaviour
{
    [SerializeField] private GameObject ScareMonster;
    [SerializeField] private Animation Scareanim;
    [SerializeField] private AnimationClip Jumpscare;
    private AudioSource jumpscaresound;
    // Start is called before the first frame update
    void Start()
    {
        ScareMonster.SetActive(false);
        jumpscaresound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScareMonster.SetActive(true);
            jumpscaresound.Play();
            Scareanim.Play(Jumpscare.name);
            StartCoroutine(SwitchScareScene());
        }

    }

    IEnumerator SwitchScareScene()
    {
        float animLenght = Jumpscare.length;
        yield return new WaitForSeconds(animLenght);
        SceneManager.LoadScene("Scary");
    }
}

