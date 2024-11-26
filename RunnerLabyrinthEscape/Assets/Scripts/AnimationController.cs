using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DisableAnimation()
    {
        if (animator != null)
        {
            
            animator.enabled = false;
        }
    }

    public void EnableAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("play");
            animator.enabled = true;

        }
    }
}
