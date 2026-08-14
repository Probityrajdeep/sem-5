<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>
<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

from enum import Enum, auto<%==SIM:Line==%>
<%==SIM:If:Element.HasDocumentation==%>"""<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%><%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>"""<%==SIM:Line==%><%==SIM:EndIf==%>
class <%==SIM:Element.Name==%>(Enum):<%==SIM:StartBlock==%><%==SIM:Line==%>
<%==SIM:ForEach:Element.Attributes==%>
    <%==SIM:ForEach:Attribute.DocumentationLines==%>#<%==SIM:DocumentationLine==%><%==SIM:Line==%>
    <%==SIM:EndFor==%><%==SIM:Attribute.Name==%> = <%==SIM:If:Attribute.HasDefaultValue==%><%==SIM:Attribute.DefaultValue==%><%==SIM:Else==%>auto()<%==SIM:EndIf==%><%==SIM:Line==%><%==SIM:EndFor==%>
<%==SIM:EndBlock==%>
