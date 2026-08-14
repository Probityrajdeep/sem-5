<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

<%==SIM:Set:private=Private==%>
<%==SIM:Set:protected=Protected==%>
<%==SIM:Set:package=Friend==%>
<%==SIM:Set:public=Public==%>

<%==SIM:ForEach:Imports==%>
    Imports <%==SIM:Import.Name==%>
    <%==SIM:Line==%>
<%==SIM:EndFor==%>

Namespace <%==SIM:Element.Namespace==%>
<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.DocumentationLines==%>
    '<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
    <%==SIM:EndFor==%>

    <%==SIM:Element.Visibility==%> Enum <%==SIM:Element.Name==%>
    <%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.Attributes==%>
	        <%==SIM:Attribute.Name==%> <%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
            <%==SIM:Line==%>

        <%==SIM:EndFor==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    End Enum

<%==SIM:EndBlock==%><%==SIM:Line==%>
End Namespace
<%==SIM:Line==%>