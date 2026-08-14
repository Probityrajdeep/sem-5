<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Template:QmlStyle(XamlElement,ElementName)==%>
<%==SIM:If:Or(IsEmpty(XamlElement.Container),XamlElement.Container.ContainerLayout.IsSimpleLayout)==%>
    x: <%==SIM:XamlElement.ClientX==%><%==SIM:Line==%>
    y: <%==SIM:XamlElement.ClientY==%><%==SIM:Line==%>
    width: <%==SIM:XamlElement.Width==%><%==SIM:Line==%>
    height: <%==SIM:XamlElement.Height==%><%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:IfNot:XamlElement.HasDefaultStyle==%>
    property color simForeground: "<%==SIM:XamlElement.Style.NameTextStyle.Color.HexA==%>"<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:EndTemplate==%>

<%==SIM:ForEach:Diagram.Elements==%>
    <%==SIM:If:Element.OfType(ui-window)==%>

import QtQuick 2.15<%==SIM:Line==%>
import QtQuick.Controls 2.15<%==SIM:Line==%>
import QtQuick.Layouts 1.15<%==SIM:Line==%>

ApplicationWindow {<%==SIM:StartBlock==%><%==SIM:Line==%>
    id: appWindow<%==SIM:Line==%>
    title: "<%==SIM:Element.OriginalName==%>"<%==SIM:Line==%>
    width: <%==SIM:Element.Width==%><%==SIM:Line==%>
    height: <%==SIM:Element.Height==%><%==SIM:Line==%>
    visible: true<%==SIM:Line==%>    

    <%==SIM:If:Or(IsEmpty(Element.ContainerLayout),Element.ContainerLayout.IsSimpleLayout)==%>
    Item {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: root<%==SIM:Line==%>
        anchors.fill: parent<%==SIM:Line==%>

        <%==SIM:ForEach:Element.NestedElements==%>
            <%==SIM:Include(Element.qml,NestedElement,False)==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}<%==SIM:Line==%>

    <%==SIM:ElseIf:Element.ContainerLayout.IsStackLayout==%>
        <%==SIM:If:Or(Eq(Element.ContainerLayout.Direction,"LeftToRight"),Eq(Element.ContainerLayout.Direction,"RightToLeft"))==%>
    Row {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: root<%==SIM:Line==%>
        anchors.fill: parent<%==SIM:Line==%>
        layoutDirection: <%==SIM:If:Eq(Element.ContainerLayout.Direction,"RightToLeft")==%>Qt.RightToLeft<%==SIM:Else==%>Qt.LeftToRight<%==SIM:EndIf==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.NestedElements==%>
            <%==SIM:Include(Element.qml,NestedElement,False)==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}<%==SIM:Line==%>
        <%==SIM:Else==%>
    Column {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: root<%==SIM:Line==%>
        anchors.fill: parent<%==SIM:Line==%>
        
        <%==SIM:ForEach:Element.NestedElements==%>
            <%==SIM:Include(Element.qml,NestedElement,False)==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}<%==SIM:Line==%>
        <%==SIM:EndIf==%>

    <%==SIM:ElseIf:Element.ContainerLayout.IsFlowLayout==%>
    Flow {<%==SIM:StartBlock==%><%==SIM:Line==%>
        id: root<%==SIM:Line==%>
        anchors.fill: parent<%==SIM:Line==%>        
        flow: <%==SIM:If:Eq(Element.ContainerLayout.Direction,"TopToBottom")==%>Flow.TopToBottom<%==SIM:Else==%>Flow.LeftToRight<%==SIM:EndIf==%><%==SIM:Line==%>
        layoutDirection: <%==SIM:If:Eq(Element.ContainerLayout.Direction,"RightToLeft")==%>Qt.RightToLeft<%==SIM:Else==%>Qt.LeftToRight<%==SIM:EndIf==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.NestedElements==%>
            <%==SIM:Include(Element.qml,NestedElement,False)==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>}<%==SIM:Line==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>}<%==SIM:Line==%>
<%==SIM:Line==%>

    <%==SIM:EndIf==%>
<%==SIM:EndFor==%>
