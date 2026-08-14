<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:If:Or(IsEmpty(Element.ContainerLayout),Element.ContainerLayout.IsSimpleLayout)==%>
Item {<%==SIM:StartBlock==%><%==SIM:Line==%>
    id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
    <%==SIM:QmlStyle(Element,"Item")==%><%==SIM:Line==%>

<%==SIM:ElseIf:Element.ContainerLayout.IsStackLayout==%>
    <%==SIM:If:Or(Eq(Element.ContainerLayout.Direction,"LeftToRight"),Eq(Element.ContainerLayout.Direction,"RightToLeft"))==%>
Row {<%==SIM:StartBlock==%><%==SIM:Line==%>
    id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
    <%==SIM:QmlStyle(Element,"Row")==%><%==SIM:Line==%>
    layoutDirection: <%==SIM:If:Eq(Element.ContainerLayout.Direction,"RightToLeft")==%>Qt.RightToLeft<%==SIM:Else==%>Qt.LeftToRight<%==SIM:EndIf==%><%==SIM:Line==%>
    spacing: 4<%==SIM:Line==%>
<%==SIM:Else==%>
Column {<%==SIM:StartBlock==%><%==SIM:Line==%>
    id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
    <%==SIM:QmlStyle(Element,"Column")==%><%==SIM:Line==%>
    spacing: 4<%==SIM:Line==%>    
<%==SIM:EndIf==%>

<%==SIM:ElseIf:Element.ContainerLayout.IsFlowLayout==%>
Flow {<%==SIM:StartBlock==%><%==SIM:Line==%>
    id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
    <%==SIM:QmlStyle(Element,"Flow")==%><%==SIM:Line==%>
    flow: <%==SIM:If:Eq(Element.ContainerLayout.Direction,"TopToBottom")==%>Flow.TopToBottom<%==SIM:Else==%>Flow.LeftToRight<%==SIM:EndIf==%><%==SIM:Line==%>
    layoutDirection: <%==SIM:If:Eq(Element.ContainerLayout.Direction,"RightToLeft")==%>Qt.RightToLeft<%==SIM:Else==%>Qt.LeftToRight<%==SIM:EndIf==%><%==SIM:Line==%>
    spacing: 4<%==SIM:Line==%>

    <%==SIM:ForEach:Element.NestedElements==%>
        <%==SIM:Include(Element.qml,NestedElement,False)==%><%==SIM:Line==%>
    <%==SIM:EndFor==%>

    <%==SIM:If:GT(Element.NestedElements.FilterByType(ui-radio-button).Count,0)==%>
    ButtonGroup {<%==SIM:StartBlock==%><%==SIM:Line==%>
        buttons: [<%==SIM:Line==%>
            <%==SIM:ForEach:Element.NestedElements.FilterByType(ui-radio-button)==%>
                <%==SIM:NestedElement.SafeName==%>,<%==SIM:Line==%>
            <%==SIM:EndFor==%>
        ]<%==SIM:Line==%>
    <%==SIM:EndBlock==%>}<%==SIM:Line==%>
    <%==SIM:EndIf==%>

<%==SIM:EndBlock==%>}<%==SIM:Line==%>
