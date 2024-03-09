Option Explicit
Dim msg, result
Dim WshShell, my_msg, wrap

Set WshShell = WScript.CreateObject("WScript.Shell")

msg=INPUTBOX("")
result =  WshShell.Popup(msg, 0, "Заголовок", vbAbortRetryIgnore + vbQuestion)
 
Select case result
    case 3
        my_msg = "Нажата кнопка Прервать " & "(Код: " & result & ")"
    case 5
        my_msg = "Нажата кнопка Пропустить " & "(Код: " & result & ")"
    case 4
        my_msg = "Нажата кнопка Повтор  " & "(Код: " & result & ")"
    case else
        my_msg = "Пользователь ничего не нажал " & "(Код: " & result & ")"
End Select

MsgBox my_msg