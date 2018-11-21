using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationButton : GuiBase{

    public int option;

    public void OnClick()
    {
        if (ConversationVM.WaitingForInput)
        {
            ConversationVM.instance.CheckAnswer(option);
        }
    }

    public void SetText(string text)
    {
        this.GetComponent<TextMeshProUGUI>().text = text;
    }
}
