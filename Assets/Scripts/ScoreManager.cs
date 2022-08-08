using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ScoreItem"))
        {
            float scoreVal = float.Parse(scoreText.text) + other.gameObject.GetComponent<Scores>().scoreValue;
            scoreText.text = "" + scoreVal;
            Destroy(other.gameObject);
        }
    }
}
