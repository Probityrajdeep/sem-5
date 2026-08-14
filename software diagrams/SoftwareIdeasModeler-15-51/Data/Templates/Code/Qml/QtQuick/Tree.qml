<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

Item {<%==SIM:StartBlock==%><%==SIM:Line==%>
    id: <%==SIM:Element.SafeName==%><%==SIM:Line==%>
    <%==SIM:QmlStyle(Element,"TreeView")==%><%==SIM:Line==%>

    Column {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: treeRoot<%==SIM:Line==%>
        anchors.fill: parent<%==SIM:Line==%>
        spacing: 2<%==SIM:Line==%>

        <%==SIM:ForEach:Element.Nodes==%>
            Item {<%==SIM:StartBlock==%><%==SIM:Line==%>
                width: parent.width<%==SIM:Line==%>
                property bool hasChildren: <%==SIM:GT(Node.Nodes.Count,0)==%><%==SIM:Line==%>
                property bool expanded: <%==SIM:Not(Node.IsCollapsed)==%><%==SIM:Line==%>

                Row {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    spacing: 4<%==SIM:Line==%>
                    ToolButton {<%==SIM:StartBlock==%><%==SIM:Line==%>
                        visible: hasChildren<%==SIM:Line==%>
                        text: expanded ? "▾" : "▸"<%==SIM:Line==%>
                        onClicked: expanded = !expanded<%==SIM:Line==%>
                    <%==SIM:EndBlock==%>}<%==SIM:Line==%>
                    Label {<%==SIM:StartBlock==%><%==SIM:Line==%>
                        text: "<%==SIM:Node.Name==%>"<%==SIM:Line==%>
                    <%==SIM:EndBlock==%>}<%==SIM:Line==%>
                <%==SIM:EndBlock==%>}<%==SIM:Line==%>

                Loader {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    active: expanded && hasChildren<%==SIM:Line==%>
                    sourceComponent: Column {<%==SIM:StartBlock==%><%==SIM:Line==%>
                        anchors.leftMargin: 16<%==SIM:Line==%>
                        spacing: 2<%==SIM:Line==%>
                        <%==SIM:Include(TreeItems.qml,Node,False)==%><%==SIM:Line==%>
                    <%==SIM:EndBlock==%>}<%==SIM:Line==%>
                <%==SIM:EndBlock==%>}<%==SIM:Line==%>
            <%==SIM:EndBlock==%>}<%==SIM:Line==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndBlock==%>}<%==SIM:Line==%>
<%==SIM:EndBlock==%>}<%==SIM:Line==%>
