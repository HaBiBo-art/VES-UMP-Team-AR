using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonsAnimationController : MonoBehaviour
{
    public GameObject parentObject; // The parent GameObject containing all animated objects

    public void StopAllAnimations()
    {
        // Get all Animator components in the children of the parent GameObject
        Animator[] animators = parentObject.GetComponentsInChildren<Animator>();

        foreach (Animator animator in animators)
        {
            animator.Rebind(); // Reset the Animator to its default state
            animator.Update(0); // Force the Animator to update
        }
    }

    public void ResumeAllAnimations()
    {
        Animator[] animators = parentObject.GetComponentsInChildren<Animator>();

        foreach (Animator animator in animators)
        {
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, -1, 0f); // Restart the animation from the beginning
        }
    }
}
