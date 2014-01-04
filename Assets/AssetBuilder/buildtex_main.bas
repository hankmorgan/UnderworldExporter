Attribute VB_Name = "buildtex_main"
Option Explicit
'0       1        2                       3       4      5   6   7     8       9      10       11     12
'Index   Type    Description             TileX   TileY   x   y   z   heading qual    owner   link    flags
Const objINDEX = 0
Const objType = 1
Const objDescription = 2
Const objTileX = 3
Const objTileY = 4
Const objX = 5
Const objY = 6
Const objZ = 7
Const objHeading = 8
Const objQual = 9
Const objOwner = 10
Const objLink = 11
Const objFlags = 12
Const objVarVal = 13

Dim currentlevel As String

Sub main()
currentlevel = 2
'buildScriptChains
buildTex

End Sub

Sub buildTex()
Dim fileTemplate
Dim fileOut
Dim pLine As String, ptmp As String, pOut As String
Dim i As Integer
fileTemplate = FreeFile 'App.Path & "\template.mtr"

Open App.Path & "\template.mtr" For Input As #fileTemplate

While EOF(fileTemplate) = False
    Line Input #fileTemplate, ptmp
    pLine = pLine & ptmp & vbCr
Wend
Close fileTemplate

For i = 0 To 272
    fileOut = FreeFile
    Open App.Path & "\shock_" & Format(i, "00#") & ".mtr" For Output As #fileOut
    pOut = Replace(pLine, "<<texpath>>", "textures\shock\shock_" & Format(i, "00#"))
    Print #fileOut, pOut

    Close fileOut
Next i

End Sub

Sub buildWriting()
Dim fileTemplate
Dim fileStringsIn
Dim fileOut
Dim pLine As String, ptmp As String, pOut As String
Dim i As Integer
Dim ptmpArray() As String
fileTemplate = FreeFile 'App.Path & "\template.txt"

Open App.Path & "\sign_template.xd" For Input As #fileTemplate
While EOF(fileTemplate) = False
    Line Input #fileTemplate, ptmp
    pLine = pLine & ptmp & vbCr
Wend
Close fileTemplate



        fileOut = FreeFile
        Open App.Path & "\signs_uw1.xd" For Output As #fileOut

fileStringsIn = FreeFile
Open App.Path & "\sign_strings.txt" For Input As #fileStringsIn
While EOF(fileStringsIn) = False
    Line Input #fileStringsIn, ptmp
    ptmpArray = Split(ptmp, "=")
    
    If Len(ptmp) Then
        pOut = Replace(pLine, "<<string_no>>", Format(ptmpArray(0), "00#"))
        pOut = Replace(pOut, "<<gamename>>", "uw1")
        pOut = Replace(pOut, "<<string_contents>>", Replace(ptmpArray(1), Chr(34), "'"))
        Print #fileOut, pOut

    End If
    i = i + 1
Wend
        Close fileOut
Close fileStringsIn
End Sub


Sub buildScripts()
Dim fileTemplate
Dim fileIn
Dim fileOut
Dim pLine As String, ptmp As String, pOut As String
Dim i As Integer
Dim la() As String
Dim elevatorFloats As String
Dim elevatorBlocks As String
fileTemplate = FreeFile 'App.Path & "\template.mtr"

Open App.Path & "\script_template.txt" For Input As #fileTemplate

While EOF(fileTemplate) = False
    Line Input #fileTemplate, ptmp
    pLine = pLine & ptmp & vbCr
Wend
Close fileTemplate

fileIn = FreeFile
Open App.Path & "\elevators.txt" For Input As #fileIn
While EOF(fileIn) = False
    Line Input #fileIn, ptmp
    If Len(ptmp) Then
        la = Split(ptmp, "-")
        elevatorFloats = elevatorFloats & "float elevator_" & la(11) & "_" & la(13) & "_state = " & la(5) & ";" & vbNewLine
        elevatorBlocks = elevatorBlocks & vbNewLine & getElevatorCode("elevator_" & la(11) & "_" & la(13)) & vbNewLine
    End If
Wend


    fileOut = FreeFile
    Open App.Path & "\uw1_level_1.script" For Output As #fileOut
    pLine = Replace(pLine, "<<elevatorstates>>", elevatorFloats)
    pLine = Replace(pLine, "<<elevatorblock>>", elevatorBlocks)
    Print #fileOut, pLine

    Close fileOut


End Sub

Function getElevatorCode(elevatorname As String) As String
    
    getElevatorCode = _
        "void move_" & elevatorname & "()" & vbNewLine _
            & " {  " & vbNewLine _
            & vbTab & "sys.println(" & Chr(34) & elevatorname & Chr(34) & ");" & vbNewLine _
            & vbTab & "if (" & elevatorname & "_state==8)" & vbNewLine _
            & vbTab & vbTab & " {" & vbNewLine _
            & vbTab & vbTab & "sys.println(" & Chr(34) & elevatorname & " down" & Chr(34) & ");" & vbNewLine _
            & vbTab & vbTab & " $" & elevatorname & ".move( DOWN, 80 );" & vbNewLine _
            & vbTab & vbTab & elevatorname & "_state=0;" & vbNewLine _
            & vbTab & " }" & vbNewLine _
            & "else" & vbNewLine _
            & vbTab & "{ " & vbNewLine _
            & vbTab & vbTab & "sys.println(" & Chr(34) & elevatorname & " up" & Chr(34) & ");" & vbNewLine _
            & vbTab & vbTab & "$" & elevatorname & ".move ( UP, 10 ); " & vbNewLine _
            & vbTab & vbTab & elevatorname & "_state++ ;" & vbNewLine _
            & vbTab & "}" & vbNewLine _
            & "}" & vbNewLine
End Function


'0       1        2                       3       4      5   6   7     8       9      10       11     12
'Index   Type    Description             TileX   TileY   x   y   z   heading qual    owner   link    flags
Sub buildScriptChains()
Dim fileChain
Dim pChain As String
Dim pOutput As String

Dim stage As Integer    '0 for function header, 1 for body
Dim chainArray() As String
Dim pGlobals As String
Dim pFunctionHeader As String
Dim pMain As String
Dim pFunctionBody As String
Dim TriggerTargetX As String
Dim TriggerTargetY As String
Dim TriggerQuality As String
Dim TriggerFlags  As String
Dim TriggerHomeX As String
Dim TriggerHomeY As String
Dim conditionalCount As Integer
stage = 0 'header
pMain = EntranceTeleporters(currentlevel)
fileChain = FreeFile
Open App.Path & "\script_chains.txt" For Input As #fileChain
While EOF(fileChain) = False
    Line Input #fileChain, pChain
    Select Case UCase(Trim(Left(pChain, 1)))
        Case "{"
        conditionalCount = 0
            stage = 1   'Start buiding function calls
            pFunctionBody = ""
        Case "}"
            
            stage = 0   'Build the output
            If Len(pFunctionBody) Then
                pOutput = pOutput & vbNewLine & _
                    pFunctionHeader & vbNewLine & _
                    "{" & vbNewLine & _
                    pFunctionBody & vbNewLine & addConditionals(conditionalCount) & vbNewLine & _
                    "}" & vbNewLine
            End If
            conditionalCount = 0
        Case "", "B"
            DoEvents
        Case Else
            'split the line up
            Debug.Print pChain
            chainArray = Split(pChain, vbTab)
            If stage = 0 Then
                TriggerTargetX = ""
                TriggerTargetY = ""
                TriggerQuality = ""
                'Build the function header.
                pFunctionHeader = "void start_" & Trim(chainArray(objDescription)) & "_" & Format(chainArray(objTileX), "00#") & "_" & Format(chainArray(objTileY), "00#") & "_" & chainArray(objINDEX) & "()"
                TriggerTargetX = chainArray(objQual)
                TriggerTargetY = chainArray(objOwner)
                TriggerQuality = chainArray(objQual)
                TriggerFlags = chainArray(objFlags)
                TriggerHomeX = chainArray(objTileX)
                TriggerHomeY = chainArray(objTileY)
                
            Else
                Select Case UCase(Trim(chainArray(objDescription)))
                    Case "A_DAMAGE_TRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_TELEPORT_TRAP"
                        pFunctionBody = pFunctionBody & a_teleport_trap(chainArray(objDescription), chainArray(objINDEX), chainArray(objQual), chainArray(objOwner), chainArray(objZ), TriggerHomeX, TriggerHomeY) & vbNewLine
                    Case "A_ARROW_TRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_DO_TRAP"
                        If chainArray(objQual) = 3 Then
                            AddGlobal pGlobals, chainArray(objDescription) & "_" & Format(TriggerTargetX, "00#") & "_" & Format(TriggerTargetY, "00#") & "_state", "float", TriggerFlags
                        End If
                        pFunctionBody = pFunctionBody & a_do_trap(chainArray(objQual), chainArray(objDescription) & "_" & Format(TriggerTargetX, "00#") & "_" & Format(TriggerTargetY, "00#"), chainArray(objDescription) & "_" & Format(TriggerTargetX, "00#") & "_" & Format(TriggerTargetY, "00#") & "_state")
                    Case "A_PIT_TRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_CHANGE_TERRAIN_TRAP"
                        pFunctionBody = pFunctionBody & a_change_terrain_trap(chainArray(objDescription), TriggerTargetX, TriggerTargetY, chainArray(objINDEX), chainArray(objX), chainArray(objY)) & vbNewLine
                        pMain = pMain & vbNewLine & "$" & chainArray(objDescription) & "_final_" & Format(TriggerTargetX, "00#") & "_" & Format(TriggerTargetY, "00#") & "_" & Format(chainArray(objINDEX), "00#") & ".hide();" & vbNewLine
                    Case "A_SPELLTRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_CREATE_OBJECT_TRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_DOOR_TRAP"
                        TriggerQuality = chainArray(objQual)
                        pFunctionBody = pFunctionBody & a_lock(TriggerTargetX, TriggerTargetY, TriggerQuality) & vbNewLine
                        DoEvents
                    Case "A_LOCK"
                        'pFunctionBody = pFunctionBody & a_lock(TriggerTargetX, TriggerTargetY, TriggerQuality) & vbNewLine
                        DoEvents
                    Case "A_WARD_TRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_TELL_TRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_DELETE_OBJECT_TRAP"
                        pFunctionBody = pFunctionBody & a_delete_object_trap(chainArray(objLink)) & vbNewLine
                    Case "AN_INVENTORY_TRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_SET_VARIABLE_TRAP"
                        AddGlobal pGlobals, "$var_" & chainArray(objZ), "float", 0
                        pFunctionBody = pFunctionBody & a_set_variable_trap(chainArray(objZ), chainArray(objVarVal), chainArray(objHeading) / 45)
                        DoEvents
                    Case "A_CHECK_VARIABLE_TRAP"
                        pFunctionBody = pFunctionBody & a_check_variable_trap(chainArray(objZ), chainArray(objVarVal), chainArray(objHeading) / 45)
                        conditionalCount = conditionalCount + 1
                        DoEvents
                    Case "A_COMBINATION_TRAP"
                        pFunctionBody = pFunctionBody & tobedone(chainArray(objDescription))
                        DoEvents
                    Case "A_TEXT_STRING_TRAP"
                        pFunctionBody = pFunctionBody & a_text_string_trap(chainArray(objOwner)) & vbNewLine
                    Case "A_MOVE_TRIGGER"
                        DoEvents
                        TriggerTargetX = chainArray(objQual)
                        TriggerTargetY = chainArray(objOwner)
                    Case "A_PICK_UP_TRIGGER"
                        DoEvents
                        TriggerTargetX = chainArray(objQual)
                        TriggerTargetY = chainArray(objOwner)
                    Case "A_USE_TRIGGER"
                        DoEvents
                        TriggerTargetX = chainArray(objQual)
                        TriggerTargetY = chainArray(objOwner)
                    Case "A_LOOK_TRIGGER"
                        TriggerTargetX = chainArray(objQual)
                        TriggerTargetY = chainArray(objOwner)
                        DoEvents
                    Case "A_STEP_ON_TRIGGER"
                        TriggerTargetX = chainArray(objQual)
                        TriggerTargetY = chainArray(objOwner)
                        DoEvents
                        TriggerTargetX = chainArray(objQual)
                        TriggerTargetY = chainArray(objOwner)
                        DoEvents
                    Case "AN_UNLOCK_TRIGGER"
                        TriggerTargetX = chainArray(objQual)
                        TriggerTargetY = chainArray(objOwner)
                        DoEvents
                    Case "ENCHANTMENT"  'Cast a spell
                        pFunctionBody = pFunctionBody & enchantment(chainArray(objLink)) & vbNewLine
                    Case Else
                        Debug.Print "NO MATCH" & UCase(Trim(chainArray(2)))
                End Select

            End If
    End Select
  
Wend
Dim fileOut
fileOut = FreeFile
Open App.Path & "\uw1_" & currentlevel & ".script" For Output As #fileOut
    Print #fileOut, "#ifndef __uw_" & currentlevel & "_script__" & vbNewLine & "#define  __uw_" & currentlevel & "_script__" & vbNewLine & pGlobals & vbNewLine & "void main()" & vbNewLine & vbNewLine & "{" & pMain & vbNewLine & "}" & vbNewLine & pOutput & vbNewLine & "#endif //__uw_" & currentlevel & "_script__"
    Close fileOut
End Sub

Function a_text_string_trap(stringId As String) As String
'Need to do a lookup on the string that happens here
Dim pStr As String
pStr = LookupString(9, 64 * currentlevel + stringId)
'a_text_string_trap = "sys.println(" & Chr(34) & "textstring:64*level+" & stringId & Chr(34) & ");"
a_text_string_trap = "sys.println(" & Chr(34) & pStr & Chr(34) & ");"
End Function

Function enchantment(stringId As String) As String
'Need to do a lookup on the string that happens here
Dim pStr As String

pStr = LookupString(6, stringId)
'a_text_string_trap = "sys.println(" & Chr(34) & "textstring:64*level+" & stringId & Chr(34) & ");"
enchantment = "sys.println(" & Chr(34) & pStr & Chr(34) & ");"
End Function


Function a_teleport_trap(objDesc As String, objId As String, x As String, y As String, levelNo As String, Optional triggerX As String, Optional triggerY As String) As String
If levelNo <> 0 Then
    'we are ending the level here
    
    a_teleport_trap = "sys.println(" & Chr(34) & "End Level. going to " & levelNo & Chr(34) & ");" _
        & vbNewLine _
        & "sys.setcvar(" & Chr(34) & "targetX" & Chr(34) & ", " & Chr(34) & x & Chr(34) & ");" & vbNewLine _
        & "sys.setcvar(" & Chr(34) & "targetY" & Chr(34) & ", " & Chr(34) & y & Chr(34) & ");" & vbNewLine _
        & "sys.trigger($trigger_endlevel_" & Format(triggerX, "00#") & "_" & Format(triggerY, "00#") & ");"
Else
    a_teleport_trap = "$" & Trim(objDesc) & "_" & Format(x, "00#") & "_" & Format(y, "00#") & "_" & objId & ".activate($player1);" & vbNewLine
End If
End Function


Function a_door_trap() As String
'activate the door locker object
a_door_trap = "//a door trap=do nothing but pass it's targets info to the lock object in order to fire the doorstate entity" & vbNewLine
DoEvents
End Function

Function a_do_trap(quality As String, Entity As String, State As String) As String
Entity = Trim(Entity)
State = Trim(State)
Select Case quality
    Case "2"    'A camera view
        a_do_trap = _
            "sys.wait(5);" & vbNewLine _
            & "$" & Entity & ".activate($player1); " & vbNewLine _
            & "sys.wait(10);" & vbNewLine _
            & "$" & Entity & ".activate($player1);" & vbNewLine
    Case "3"    'A moving platform
        a_do_trap = _
            " if (" & State & "==8) " & vbNewLine _
            & " { " & vbNewLine _
            & " $" & Entity & ".move( DOWN, 105 );" & vbNewLine _
            & " " & State & "=0;" & vbNewLine _
            & " } " & vbNewLine _
            & " else" & vbNewLine _
            & " {" & vbNewLine _
            & " $" & Entity & ".move ( UP, 15 );" & vbNewLine _
             & State & "++ ;" & vbNewLine _
            & " }" & vbNewLine
End Select
End Function

Function a_lock(doorX As String, doorY As String, targetState As String)
Dim pmsg As String
pmsg = "sys.println(" & Chr(34) & "Lock -targetstate=" & targetState & Chr(34) & ");" & vbNewLine
Select Case targetState
    Case 1      ' try open
        a_lock = pmsg & "$a_door_" & Format(doorX, "00#") & "_" & Format(doorY, "00#") & ".Open();" & vbNewLine
        'a_lock = "$a_lock_" & Format(doorX, "00#") & "_" & Format(doorY, "00#") & ".activate($player1);" & vbNewLine
    Case 2      ' try close
        a_lock = pmsg _
            & "$a_door_" & Format(doorX, "00#") & "_" & Format(doorY, "00#") & ".Close();" & vbNewLine _
            & "sys.wait(5);" & vbNewLine _
            & "$a_door_" & Format(doorX, "00#") & "_" & Format(doorY, "00#") & ".Lock();" & vbNewLine _

    Case Else    ' 3: toggle door state
        a_lock = pmsg & "$a_lock_" & Format(doorX, "00#") & "_" & Format(doorY, "00#") & ".activate($player1);" & vbNewLine
    End Select
End Function

Function a_change_terrain_trap(string_desc As String, targetX As String, targetY As String, string_id As String, dimX As String, dimY As String)
Dim pDim As String
Dim i As Integer
Dim j As Integer
Dim k As Integer
k = 0
For i = 0 To dimX
    For j = 0 To dimY
        pDim = pDim & "$" & string_desc & "_initial_" & Format(targetX, "00#") & "_" & Format(targetY, "00#") & "_" & Format(string_id, "00#") & "_" & Format(k, "00#") & ".remove();" & vbNewLine
        k = k + 1
    Next j
Next i

'a_change_terrain_trap = "$" & string_desc & "_initial_" & Format(targetX, "00#") & "_" & Format(targetY, "00#") & "_" & Format(string_id, "00#") & ".hide();" & vbNewLine _
    & "$" & string_desc & "_final_" & Format(targetX, "00#") & "_" & Format(targetY, "00#") & "_" & Format(string_id, "00#") & ".show();" & vbNewLine
    
a_change_terrain_trap = pDim & vbNewLine _
    & "$" & string_desc & "_final_" & Format(targetX, "00#") & "_" & Format(targetY, "00#") & "_" & Format(string_id, "00#") & ".show();" & vbNewLine


End Function

Function a_delete_object_trap(objectToDelete As String)
Dim pObj As String
pObj = LookupObject(objectToDelete)
If Len(pObj) Then
    Dim pArray() As String
    pArray = Split(pObj, vbTab)
    a_delete_object_trap = "$" & Trim(pArray(objDescription)) & "_" & Format(pArray(objTileX), "00#") & "_" & Format(pArray(objTileY), "00#") & "_" & Format(pArray(objINDEX), "00#") & ".hide();"
End If
End Function

Function LookupObject(find As String) As String
Dim fileObj
Dim ptmp As String
fileObj = FreeFile

Open App.Path & "\object_list.txt" For Input As #fileObj
While EOF(fileObj) = False
Line Input #fileObj, ptmp
If (Left(ptmp, Len(find)) = find) Then
    Close fileObj
    LookupObject = ptmp
    Exit Function
End If
Wend
Close fileObj
Debug.Print "object not found!"
LookupObject = ""
End Function


Sub AddGlobal(ByRef pGlobals As String, ByVal GlobalToAdd As String, ByVal globalType As String, ByVal InitialValue As String)
If (InStr(1, pGlobals, GlobalToAdd)) = 0 Then
    pGlobals = pGlobals & " " & globalType & " " & GlobalToAdd & "=" & InitialValue & ";" & vbNewLine
End If
End Sub

Function LookupString(BlockNo As String, StringNo As String) As String
Dim fileObj
Dim ptmp As String
fileObj = FreeFile
Dim find As String
find = "Block Name: " & BlockNo
Open App.Path & "\strings_clean.txt" For Input As #fileObj
While EOF(fileObj) = False
Line Input #fileObj, ptmp
If (Left(ptmp, Len(find)) = find) Then
    'found our block
    'now find our String
    While EOF(fileObj) = False
       Line Input #fileObj, ptmp
       If Left(ptmp, 3) = Left(Format(StringNo, "00#"), 3) Then
            'found string
            LookupString = Split(ptmp, "=")(1)
            Exit Function
       End If
    Wend
    Close fileObj
    LookupString = "" 'ptmp
    Exit Function
End If
Wend
Close fileObj
Debug.Print "object not found!"
LookupString = ""
End Function


Function EntranceTeleporters(levelNo As String)
Dim fileEntr
Dim ptmp As String
Dim pOut As String
levelNo = Trim(levelNo)
fileEntr = FreeFile
Open App.Path & "\uw1_entrances.txt" For Input As #fileEntr
While EOF(fileEntr) = False
    Line Input #fileEntr, ptmp
    If Left(ptmp, Len(levelNo)) = levelNo Then
        'Found an entry for this level
        pOut = pOut & vbNewLine & "if ( (sys.getcvar(" & Chr(34) & "targetX" & Chr(34) & ") == " & Chr(34) & Split(ptmp, " ")(1) & Chr(34) & ") && " & _
            "(sys.getcvar(" & Chr(34) & "targetY" & Chr(34) & ") == " & Chr(34) & Split(ptmp, " ")(2) & Chr(34) & "))" & vbNewLine & _
            "{" & vbNewLine & _
            "$entrance_" & Format(Split(ptmp, " ")(1), "00#") & "_" & Format(Split(ptmp, " ")(2), "00#") & ".activate($player1);" & vbNewLine & _
            "}" & vbNewLine
            
    End If
Wend
EntranceTeleporters = pOut
End Function

Function tobedone(name As String) As String
 tobedone = "sys.println(" & Chr(34) & "TODO: " & name & Chr(34) & ");" & vbNewLine
End Function

Function a_set_variable_trap(variable As String, value As String, operation As String) As String
Dim pOut As String
   '       heading  operation    bit-field operation
   '       0        add          set bit
   '       1        sub          clear bit
   '       2        set          set bit
   '       3        and          set bit
   '       4        or           set bit
   '       5        xor          flip bit
   '       6        shl          set bit
If variable <> "0" Then
    Select Case operation
        Case "0"  'add
            pOut = "var_" & variable & " +=" & value & ";" & vbNewLine
        Case "1"  'sub
            pOut = "var_" & variable & " -=" & value & ";" & vbNewLine
        Case "2"  'set
            pOut = "var_" & variable & " =" & value & ";" & vbNewLine
        Case "3"  'and
            pOut = "var_" & variable & " &=" & value & ";" & vbNewLine 'Does this work??
        Case "4"  'or
            pOut = "var_" & variable & " |=" & value & ";" & vbNewLine
        Case "5"  'xor ! ((a&b) & (a|b))
            pOut = "var_" & variable & " = (~( var_" & variable & " & " & value & ")) & ( var_" & variable & " | " & value & ") ;" & vbNewLine
           ' pOut = "//var_" & variable & " ^=" & value & ";" & vbNewLine
        Case "6"  'shiftleft double by value times
            pOut = "var_" & variable & " = (var_" & variable & " * " & 2 * value & ") & 63 ; " & vbNewLine
        Case Else
            Debug.Print "Unknown operation"
    End Select
'Else    'bitwise
'    Select Case operation
'        Case 0  'set
'        Case 1  'clear
'        Case 2  'set
'        Case 3  'set
'        Case 4  'set
'        Case 5  'flip
'        Case 6  'set
'    End Select
End If
pOut = pOut & vbNewLine & "sys.println(var_" & variable & ");" & vbNewLine
a_set_variable_trap = pOut
End Function

Function a_check_variable_trap(variable As String, value As String, operation As String) As String
'Will need to expand on this for more complex checks

 a_check_variable_trap = "if (var_" & variable & " == " & value & ") " & vbNewLine & "{" & vbNewLine
End Function

Function addConditionals(noofCond As Integer) As String
Dim i As Integer
Dim pOut As String
For i = 1 To noofCond
    pOut = pOut & vbNewLine & "}"
Next i
addConditionals = pOut
End Function
