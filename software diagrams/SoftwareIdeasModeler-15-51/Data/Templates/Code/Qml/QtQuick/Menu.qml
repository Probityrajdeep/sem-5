<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

menuBar: MenuBar {<%==SIM:StartBlock==%><%==SIM:Line==%>        
    <%==SIM:ForEach:Element.Items==%>
        <%==SIM:If:Eq(Item.Name,"-")==%>
            MenuSeparator {}<%==SIM:Line==%>
        <%==SIM:Else==%>
            MenuItem {<%==SIM:StartBlock==%><%==SIM:Line==%>
                text: "<%==SIM:Item.Name==%>"<%==SIM:Line==%>
                <%==SIM:If:GT(Item.Items.Count,0)==%>
                    menu: Menu {<%==SIM:StartBlock==%><%==SIM:Line==%>
                        <%==SIM:Include(MenuItems.qml,Item,False)==%><%==SIM:Line==%>
                    <%==SIM:EndBlock==%><%==SIM:Line==%>}
                <%==SIM:EndIf==%>
            <%==SIM:EndBlock==%><%==SIM:Line==%>}<%==SIM:Line==%>
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>
<%==SIM:EndBlock==%><%==SIM:Line==%>}<%==SIM:Line==%>
