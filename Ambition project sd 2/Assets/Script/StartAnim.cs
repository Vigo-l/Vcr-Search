using System.Collections;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    [SerializeField] private FpsController Player;
    [SerializeField] private Animation Animation;
    [SerializeField] private AnimationClip begin;
    [SerializeField] private GameObject IntroCamera;
    // Start is called before the first frame update
    void Start()
    {
        Player.CanMove = false;
        IntroCamera.SetActive(true);
        StartCoroutine(StartAnimation());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartAnimation()
    {
        float animationLength = begin.name.Length;
        Animation.Play(begin.name);
        yield return new WaitForSeconds(15);
        Player.CanMove = true;
        IntroCamera.SetActive(false);
    }
}
