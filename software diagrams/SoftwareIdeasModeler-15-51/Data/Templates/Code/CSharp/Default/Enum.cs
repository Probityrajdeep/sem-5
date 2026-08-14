<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:Documentation=YesNo("Documentation")==%>

<%==SIM:IfNot:Element.IsContained==%>
<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=internal==%><%==SIM:Set:public=public==%>

<%==SIM:ForEach:Imports==%>
    using <%==SIM:Import.Name==%>;
    <%==SIM:Line==%>
<%==SIM:EndFor==%>

namespace <%==SIM:Element.Namespace==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:If:Documentation==%><%==SIM:If:Element.HasDocumentation==%>
    /// <summary><%==SIM:Line==%>
<%==SIM:ForEach:Element.SimpleHtmlDocumentationLines==%>
    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    /// </summary><%==SIM:Line==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>
    
    <%==SIM:If:Element.HasStereotype("flags")==%>[Flags]<%==SIM:Line==%><%==SIM:EndIf==%>
    <%==SIM:IfNot:IsEmpty(Element.Visibility)==%><%==SIM:Element.Visibility==%> <%==SIM:EndIf==%>enum <%==SIM:Element.Name==%> <%==SIM:If:Or(Element.HasSuperClassifier)==%> : <%==SIM:Element.SuperClassifier.Name==%><%==SIM:EndIf==%>
    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.Attributes==%>
            <%==SIM:If:Documentation==%><%==SIM:If:Attribute.HasDocumentation==%>
                /// <summary><%==SIM:Line==%>
            <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
                /// </summary><%==SIM:Line==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>
    
            <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
            <%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
        <%==SIM:EndFor==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

<%==SIM:EndBlock==%><%==SIM:Line==%>
}
<%==SIM:EndIf==%>