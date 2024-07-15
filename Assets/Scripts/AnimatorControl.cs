using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{

    private Animator _animator;
    private bool _generated;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _generated = false;
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !_generated)
        {
            int rand = Random.Range(0, 3);            
            _animator.SetInteger("NextAnimation", rand);
            _generated = true;
        }
        else if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && _generated)
            _generated = false;
    }
    
}
