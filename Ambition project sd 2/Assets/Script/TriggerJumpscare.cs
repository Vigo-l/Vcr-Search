using System.Collections;
using UnityEngine;

public class TriggerJumpscare : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource ScareSound;
    [SerializeField] private AudioSource Monster;

    [Header("Animations")]
    [SerializeField] private Animation MonsterAnimations;
    [SerializeField] private AnimationClip MonsterWalk;
    [SerializeField] private AnimationClip Pickup;
    [SerializeField] private AnimationClip Drop;

    [Header("Camera")]
    [SerializeField] private Camera playerCamera; // Reference to the player's camera
    [SerializeField] private Transform monsterTransform; // Reference to the monster's transform

    private bool isLookingAtMonster = false;

    // Start is called before the first frame update
    void Start()
    {
        Monster = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLookingAtMonster)
        {
            Vector3 direction = monsterTransform.position - playerCamera.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerCamera.transform.rotation = Quaternion.Slerp(playerCamera.transform.rotation, targetRotation, Time.deltaTime * 2.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Monster.Play();
            MonsterAnimations.Play(MonsterWalk.name);
            StartCoroutine(ForceLookAtMonster());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }

    IEnumerator ForceLookAtMonster()
    {
        isLookingAtMonster = true;
        yield return new WaitForSeconds(2.0f); // Look at the monster for 2 seconds
        isLookingAtMonster = false;
        StartCoroutine(Walk());
    }

    IEnumerator Walk()
    {
        float animationDuration = MonsterWalk.length;
        yield return new WaitForSeconds(animationDuration);
        Monster.Stop();
    }
}
