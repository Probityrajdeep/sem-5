<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:ForEach:Input.Nodes(NestedNode)==%>
    Item {<%==SIM:StartBlock==%><%==SIM:Line==%>
        width: parent.width<%==SIM:Line==%>
        property bool hasChildren: <%==SIM:GT(NestedNode.Nodes.Count,0)==%><%==SIM:Line==%>
        property bool expanded: <%==SIM:Not(NestedNode.IsCollapsed)==%><%==SIM:Line==%>

        Row {<%==SIM:StartBlock==%><%==SIM:Line==%>
            spacing: 4<%==SIM:Line==%>
            ToolButton {<%==SIM:StartBlock==%><%==SIM:Line==%>
                visible: hasChildren<%==SIM:Line==%>
                text: expanded ? "▾" : "▸"<%==SIM:Line==%>
                onClicked: expanded = !expanded<%==SIM:Line==%>
            <%==SIM:EndBlock==%>}<%==SIM:Line==%>
            Label {<%==SIM:StartBlock==%><%==SIM:Line==%>
                text: "<%==SIM:NestedNode.Name==%>"<%==SIM:Line==%>
            <%==SIM:EndBlock==%>}<%==SIM:Line==%>
        <%==SIM:EndBlock==%>}<%==SIM:Line==%>

        Loader {<%==SIM:StartBlock==%><%==SIM:Line==%>
            active: expanded && hasChildren<%==SIM:Line==%>
            sourceComponent: Column {<%==SIM:StartBlock==%><%==SIM:Line==%>
                anchors.leftMargin: 16<%==SIM:Line==%>
                spacing: 2<%==SIM:Line==%>
                <%==SIM:Include(TreeItems.qml,NestedNode,False)==%><%==SIM:Line==%>
            <%==SIM:EndBlock==%>}<%==SIM:Line==%>
        <%==SIM:EndBlock==%>}<%==SIM:Line==%>
    <%==SIM:EndBlock==%>}<%==SIM:Line==%>
<%==SIM:EndFor==%>
