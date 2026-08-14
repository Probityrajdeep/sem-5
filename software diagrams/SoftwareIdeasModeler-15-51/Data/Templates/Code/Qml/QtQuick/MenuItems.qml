<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:ForEach:Element.Items(NestedItem)==%>
    <%==SIM:If:Eq(NestedItem.Name,"-")==%>
        MenuSeparator {}<%==SIM:Line==%>
    <%==SIM:Else==%>
        MenuItem {<%==SIM:StartBlock==%><%==SIM:Line==%>
            text: "<%==SIM:NestedItem.Name==%>"<%==SIM:Line==%>
            <%==SIM:If:GT(NestedItem.Items.Count,0)==%>
                menu: Menu {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    <%==SIM:Include(MenuItems.qml,NestedItem,False)==%><%==SIM:Line==%>
                <%==SIM:EndBlock==%><%==SIM:Line==%>}
            <%==SIM:EndIf==%>
        <%==SIM:EndBlock==%><%==SIM:Line==%>}
    <%==SIM:EndIf==%>
<%==SIM:EndFor==%>
