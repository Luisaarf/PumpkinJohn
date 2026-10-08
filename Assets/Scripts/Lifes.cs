using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Lifes : MonoBehaviour
{
    [SerializeField] private int maxLife = 6;
    public int currLife { get; private set; }
    public bool Dead => currLife <= 0;
    public event Action<int> onChangeQuantLife;
    void Awake()
    {
        currLife = maxLife;
    }
    void Start(){ 
        onChangeQuantLife?.Invoke(currLife);
    }
    public void TakeDamage(int hit = 1)
    {
        if (Dead) return;
        currLife = Mathf.Max(0, currLife - hit);
        if (currLife == 0){
            SceneManager.LoadScene("GameOver");
        }  else {
            onChangeQuantLife?.Invoke(currLife);
        }
    }
}