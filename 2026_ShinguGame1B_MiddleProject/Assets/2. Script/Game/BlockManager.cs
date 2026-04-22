using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject white, black;
    public bool iswhite = false;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.Instance.PlaySFX("Change");

            iswhite = !iswhite;

            animator.SetBool("iswhite", iswhite);
        }

        if (!iswhite)
        {
            black.SetActive(false);
            white.SetActive(true);
        }
        else
        {
            black.SetActive(true);
            white.SetActive(false);
        }

    }
}
