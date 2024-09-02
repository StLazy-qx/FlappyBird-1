using System.Collections.Generic;
using UnityEngine;

public class BirdBulletPool : Pool<BirdBullet> 
{
    [SerializeField]private Bird _bird;

    private void OnEnable()
    {
        _bird.GameOver += Reset;
    }

    private void OnDisable()
    {
        _bird.GameOver -= Reset;
    }
}