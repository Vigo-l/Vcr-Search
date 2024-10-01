using UnityEngine;

public class loop : MonoBehaviour
{
    Animation animat;
    [SerializeField] private AnimationClip clip;
    // Start is called before the first frame update
    void Start()
    {
        animat = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animat.isPlaying == false)
        {
            animat.Play(clip.name);
        }

    }
}
