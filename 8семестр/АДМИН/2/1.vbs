Option Explicit
Dim msg, result
Dim WshShell, my_msg, wrap

Set WshShell = WScript.CreateObject("WScript.Shell")

msg=INPUTBOX("")
result =  WshShell.Popup(msg, 0, "���������", vbAbortRetryIgnore + vbQuestion)
 
Select case result
    case 3
        my_msg = "������ ������ �������� " & "(���: " & result & ")"
    case 5
        my_msg = "������ ������ ���������� " & "(���: " & result & ")"
    case 4
        my_msg = "������ ������ ������  " & "(���: " & result & ")"
    case else
        my_msg = "������������ ������ �� ����� " & "(���: " & result & ")"
End Select

MsgBox my_msg