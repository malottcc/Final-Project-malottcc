using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class WaveWhenClose : MonoBehaviour
{

   
    public NPCConversation conv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        ConversationManager.Instance.StartConversation(conv);
    }
}
