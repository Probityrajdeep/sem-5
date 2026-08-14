<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=public==%><%==SIM:Set:public=public==%>

<?php
<%==SIM:Line==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
  //<%==SIM:DocumentationLine==%>
  <%==SIM:Line==%>
<%==SIM:EndFor==%>

final class <%==SIM:Element.Name==%> {
<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.Attributes==%>
  
  <%==SIM:ForEach:Element.DocumentationLines==%>
    //<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
  <%==SIM:EndFor==%>    
  
  const <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
  <%==SIM:Line==%>
  
<%==SIM:EndFor==%>

    <%==SIM:Line==%>
    private function __construct(){}
    
<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
?>

<%==SIM:Line==%>