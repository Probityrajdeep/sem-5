<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

ToolBar {<%==SIM:StartBlock==%><%==SIM:Line==%>
    id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
    <%==SIM:QmlStyle(Element,"ToolBar")==%><%==SIM:Line==%>

    Row {<%==SIM:StartBlock==%><%==SIM:Line==%>
        spacing: 4<%==SIM:Line==%>
        <%==SIM:ForEach:Element.NestedElements==%>
            <%==SIM:Include(Element.qml,NestedElement,False)==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}
<%==SIM:EndBlock==%><%==SIM:Line==%>}
