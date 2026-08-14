<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:If:Element.OfType(ui-panel)==%>
    <%==SIM:Include(Panel.qml,Element,False)==%><%==SIM:Line==%>
<%==SIM:ElseIf:Element.OfType(ui-tab-control)==%>
    <%==SIM:Include(TabControl.qml,Element,False)==%><%==SIM:Line==%>
<%==SIM:ElseIf:Element.OfType(ui-toolbar)==%>
    <%==SIM:Include(Toolbar.qml,Element,False)==%><%==SIM:Line==%>
<%==SIM:ElseIf:Element.OfType(ui-menu)==%>
    <%==SIM:Include(Menu.qml,Element,False)==%><%==SIM:Line==%>
<%==SIM:ElseIf:Element.OfType(ui-tree)==%>
    <%==SIM:Include(Tree.qml,Element,False)==%><%==SIM:Line==%>

<%==SIM:ElseIf:Element.OfType(ui-button)==%>
    Button {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        text: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"Button")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-check-box)==%>
    CheckBox {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        text: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"CheckBox")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-radio-button)==%>
    RadioButton {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        text: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"RadioButton")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-label)==%>
    Label {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        text: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"Label")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-grid)==%>
    GridLayout {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"GridLayout")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(image)==%>
    Image {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"Image")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:And(Element.OfType(ui-text-box),Not(Element.ShowPasswordDots))==%>
    TextField {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        text: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"TextField")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-multi-line)==%>
    TextArea {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        text: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
        wrapMode: Text.WordWrap<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"TextArea")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:And(Element.OfType(ui-text-box),Element.ShowPasswordDots)==%>
    TextField {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        echoMode: TextInput.Password<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"PasswordField")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-combo-box)==%>
    ComboBox {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        editable: true<%==SIM:Line==%>
        currentText: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"ComboBox")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-list-box)==%>
    ListView {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        model: 10<%==SIM:Line==%>
        delegate: Text { text: "Item " + (index + 1) }<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"ListView")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-calendar)==%>
    Calendar {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"Calendar")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-date-picker)==%>
    DatePicker {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"DatePicker")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-group-box)==%>
    GroupBox {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        title: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"GroupBox")==%><%==SIM:Line==%>
        <%==SIM:Include(Panel.qml,Element,False)==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-track-bar)==%>
    Slider {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"Slider")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-progress-bar)==%>
    ProgressBar {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"ProgressBar")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:ElseIf:Element.OfType(ui-scroll-bar)==%>
    ScrollBar {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
        orientation: <%==SIM:If:GT(Element.Width,Element.Height)==%>Qt.Horizontal<%==SIM:Else==%>Qt.Vertical<%==SIM:EndIf==%><%==SIM:Line==%>
        <%==SIM:QmlStyle(Element,"ScrollBar")==%><%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
    
<%==SIM:EndIf==%>
