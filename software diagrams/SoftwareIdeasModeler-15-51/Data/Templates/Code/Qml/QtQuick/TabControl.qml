<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

TabView {<%==SIM:StartBlock==%><%==SIM:Line==%>
    id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
    <%==SIM:QmlStyle(Element,"TabView")==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.Tabs==%>
        Tab {<%==SIM:StartBlock==%><%==SIM:Line==%>
            title: "<%==SIM:Tab.Name==%>"<%==SIM:Line==%>
            Item {<%==SIM:StartBlock==%><%==SIM:Line==%>
                anchors.fill: parent<%==SIM:Line==%>
                <%==SIM:ForEach:Tab.NestedElements==%>
                    <%==SIM:Include(Element.qml,NestedElement,False)==%><%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:If:GT(Tab.NestedElements.FilterByType(ui-radio-button).Count,0)==%>
                ButtonGroup {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    buttons: [<%==SIM:Line==%>
                        <%==SIM:ForEach:Tab.NestedElements.FilterByType(ui-radio-button)==%>
                            <%==SIM:NestedElement.SafeName==%>,<%==SIM:Line==%>
                        <%==SIM:EndFor==%>
                    ]<%==SIM:Line==%>
                <%==SIM:EndBlock==%>}<%==SIM:Line==%>
                <%==SIM:EndIf==%>

            <%==SIM:EndBlock==%><%==SIM:Line==%>}<%==SIM:Line==%>
        <%==SIM:EndBlock==%><%==SIM:Line==%>}
    <%==SIM:EndFor==%>
<%==SIM:EndBlock==%><%==SIM:Line==%>}
