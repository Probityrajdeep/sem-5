<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:Documentation=YesNo("Documentation")==%>

<%==SIM:IfNot:Element.IsContained==%>
<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=internal==%><%==SIM:Set:public=public==%>

<%==SIM:ForEach:Imports==%>
#include <%==SIM:Import.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>
<%==SIM:IfNot:IsBlank(Element.Namespace)==%>
namespace <%==SIM:Element.Namespace("::")==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>
<%==SIM:EndIf==%>

<%==SIM:If:Documentation==%><%==SIM:If:Element.HasDocumentation==%>
/**<%==SIM:Line==%><%==SIM:ForEach:Element.DocumentationLines==%>
 * <%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%> */<%==SIM:Line==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>
        
    <%==SIM:IfNot:IsEmpty(Element.Visibility)==%><%==SIM:Element.Visibility==%> <%==SIM:EndIf==%>enum <%==SIM:IfNot:Element.HasStereotype("plain")==%>class <%==SIM:EndIf==%><%==SIM:Element.Name==%> <%==SIM:If:Or(Element.HasSuperClassifier)==%> : <%==SIM:Element.SuperClassifier.Name==%><%==SIM:EndIf==%>
    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.Attributes==%>
            <%==SIM:If:Documentation==%><%==SIM:If:Attribute.HasDocumentation==%>
                /**<%==SIM:Line==%>
            <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                 * <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
                 */ </summary><%==SIM:Line==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>
    
            <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
            <%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
        <%==SIM:EndFor==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

<%==SIM:IfNot:IsBlank(Element.Namespace)==%>
<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%> 
<%==SIM:EndIf==%>