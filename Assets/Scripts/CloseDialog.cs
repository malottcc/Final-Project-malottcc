using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CloseDialog : MonoBehaviour
{

    public NPCConversation convo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseConvo()
    {
        ConversationManager.Instance.EndConversation();
    }


}
