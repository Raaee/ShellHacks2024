using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }
}
