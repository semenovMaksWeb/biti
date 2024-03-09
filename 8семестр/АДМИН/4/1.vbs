Dim arr
arr = Array( 1, 7, 2, 6, 3, 5, 4)
index = -1
for each value in arr
    index = index + 1
    if index = Len(msg) then 
        msg = msg & value & ","
    else 
        msg = msg & value & "."
    End If 
next
MsgBox msg