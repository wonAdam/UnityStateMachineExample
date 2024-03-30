using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    [SerializeField]
    string _initialState;

    [SerializeField]
    string _stateToPlay;

    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_stateToPlay) == false)
            {
                _animator.Play(_stateToPlay, 0);
            }
        }
        else
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_initialState) == false)
            {
                _animator.Play(_initialState, 0);
            }
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_stateToPlay) ) 
        {
            Debug.Log($"Playing {_stateToPlay}");
        }
    }
}
