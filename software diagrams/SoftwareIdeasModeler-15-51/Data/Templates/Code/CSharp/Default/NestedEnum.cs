<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:Documentation=YesNo("Documentation")==%>

<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=internal==%><%==SIM:Set:public=public==%>

<%==SIM:If:Documentation==%><%==SIM:If:Element.HasDocumentation==%>
    /// <summary><%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    /// </summary><%==SIM:Line==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>

<%==SIM:If:Element.HasStereotype("flags")==%>[Flags]<%==SIM:Line==%><%==SIM:EndIf==%>
<%==SIM:Element.Visibility==%> enum <%==SIM:Element.Name==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.Attributes==%>        
        <%==SIM:If:Documentation==%><%==SIM:If:Attribute.HasDocumentation==%>        
            /// <summary><%==SIM:Line==%>
        <%==SIM:ForEach:Attribute.DocumentationLines==%>
            /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
            /// </summary><%==SIM:Line==%>
        <%==SIM:EndIf==%><%==SIM:EndIf==%>
    
        <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
        <%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}
<%==SIM:Line(2)==%>
