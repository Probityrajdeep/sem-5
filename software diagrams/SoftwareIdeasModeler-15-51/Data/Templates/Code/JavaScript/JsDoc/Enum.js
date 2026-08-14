<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:IfNot:Element.IsContained==%>
<%==SIM:Set:private===%>
<%==SIM:Set:protected===%>
<%==SIM:Set:package===%>
<%==SIM:Set:public===%>

/**
<%==SIM:ForEach:Element.DocumentationLines==%>
    *<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    * @enum {string}<%==SIM:Line==%>
*/<%==SIM:Line==%>
        
<%==SIM:Element.Visibility==%> const <%==SIM:Element.Name==%> =
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.Attributes==%>
        <%==SIM:ForEach:Attribute.DocumentationLines==%>
            //<%==SIM:DocumentationLine==%>
            <%==SIM:Line==%>
        <%==SIM:EndFor==%>
    
        <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%>: "<%==SIM:Attribute.DefaultValue==%>"<%==SIM:EndIf==%>
        <%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}
<%==SIM:EndIf==%>