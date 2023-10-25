using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class placeChange : MonoBehaviour
{
    Animator animator;
    private AudioSource finishShound;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        finishShound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Advanced")
        {
            animator.SetBool("Advanced", true);
        }
    }
    private void finsihLevel()
    {
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        animator.SetBool("Advanced", false);
    }
}
