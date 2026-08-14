<%==SIM:ExplicitLinesOn==%>
<%==SIM:AutoIndentOn==%>
<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=public==%>
<%==SIM:Set:public=public==%>

<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>
<%==SIM:UserInput:Documentation=YesNo("Documentation")==%>

<%==SIM:Template:ParameterTemplate(Typable)==%>
<%==SIM:If:Typable.IsOut==%>[Out]<%==SIM:EndIf==%>
<%==SIM:If:Or(Typable.IsArray,Typable.ReturnIsArray)==%>
<%==SIM:If:Typable.IsUnique==%><%==SIM:If:Typable.IsOrdered==%>set<<%==SIM:Typable.Type==%>> <%==SIM:If:Typable.IsReference==%>&<%==SIM:EndIf==%><%==SIM:Typable.Name==%><%==SIM:Else==%>unordered_set<<%==SIM:Typable.Type==%>> <%==SIM:If:Typable.IsReference==%>&<%==SIM:EndIf==%><%==SIM:Typable.Name==%><%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:If:Typable.IsOrdered==%><%==SIM:If:Or(Eq(ArrayType,"Array"), IsEmpty(ArrayType))==%><%==SIM:Typable.Type==%> <%==SIM:Typable.Name==%>[]<%==SIM:Else==%><%==SIM:ArrayType==%><<%==SIM:Typable.Type==%>> <%==SIM:Typable.Name==%><%==SIM:EndIf==%>
<%==SIM:Else==%><%==SIM:Typable.Type==%> <%==SIM:If:Typable.IsReference==%>&<%==SIM:EndIf==%><%==SIM:Typable.Name==%>[]<%==SIM:EndIf==%>
<%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:Typable.Type==%> <%==SIM:If:Typable.IsReference==%>&<%==SIM:EndIf==%><%==SIM:Typable.Name==%>
<%==SIM:EndIf==%>
<%==SIM:EndTemplate==%>

<%==SIM:Template:ReturnTypeTemplate(Typable)==%>
<%==SIM:If:Operation.HasReturnType==%>
<%==SIM:If:Or(Typable.IsArray,Typable.ReturnIsArray)==%>
<%==SIM:If:Typable.IsUnique==%><%==SIM:If:Typable.IsOrdered==%>set<<%==SIM:Typable.Type==%>> <%==SIM:If:Typable.IsReference==%>&<%==SIM:EndIf==%><%==SIM:Typable.Name==%><%==SIM:Else==%>unordered_set<<%==SIM:Typable.Type==%>> <%==SIM:If:Typable.IsReference==%>&<%==SIM:EndIf==%><%==SIM:Typable.Name==%><%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:If:Typable.IsOrdered==%><%==SIM:If:Or(Eq(ArrayType,"Array"), IsEmpty(ArrayType))==%><%==SIM:Typable.Type==%> <%==SIM:Typable.Name==%>[]<%==SIM:Else==%><%==SIM:ArrayType==%><<%==SIM:Typable.Type==%>> <%==SIM:Typable.Name==%><%==SIM:EndIf==%>
<%==SIM:Else==%><%==SIM:Typable.Type==%> <%==SIM:If:Typable.IsReference==%>&<%==SIM:EndIf==%><%==SIM:Typable.Name==%>[]<%==SIM:EndIf==%>
<%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:Typable.Type==%>
<%==SIM:EndIf==%>
<%==SIM:Else==%>void<%==SIM:EndIf==%>
<%==SIM:EndTemplate==%>

<%==SIM:ForEach:Imports==%>
#include <%==SIM:Import.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>
#include "<%==SIM:Element.Name==%>.h"<%==SIM:Line==%>
<%==SIM:Line==%>

<%==SIM:ForEach:Element.Constructors==%>
<%==SIM:If:Documentation==%><%==SIM:If:Or(Constructor.HasDocumentation,Constructor.HasNestedDocumentation)==%>
/**<%==SIM:ForEach:Constructor.DocumentationLines==%><%==SIM:Line==%>
*<%==SIM:DocumentationLine==%><%==SIM:EndFor==%><%==SIM:Line==%><%==SIM:ForEach:Constructor.Parameters==%>
* @param <%==SIM:Parameter.Name==%> <%==SIM:ToSingleLine(Parameter.Documentation)==%><%==SIM:Line==%><%==SIM:EndFor==%>
*/<%==SIM:Line==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:IfNot:IsBlank(Element.Namespace)==%><%==SIM:Element.Namespace("::")==%>::<%==SIM:EndIf==%><%==SIM:Element.Name==%>::<%==SIM:Element.Name==%> (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>
<%==SIM:Constructor.SourceCodeBody==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%><%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Destructors==%>
<%==SIM:If:Documentation==%><%==SIM:If:Or(Destructor.HasDocumentation,Destructor.HasNestedDocumentation)==%>
/**<%==SIM:ForEach:Destructor.DocumentationLines==%><%==SIM:Line==%>
*<%==SIM:DocumentationLine==%><%==SIM:EndFor==%><%==SIM:Line==%><%==SIM:ForEach:Desstructor.Parameters==%>
* @param <%==SIM:Parameter.Name==%> <%==SIM:ToSingleLine(Parameter.Documentation)==%><%==SIM:Line==%><%==SIM:EndFor==%>
*/<%==SIM:Line==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:IfNot:IsBlank(Element.Namespace)==%><%==SIM:Element.Namespace("::")==%>::<%==SIM:EndIf==%><%==SIM:Element.Name==%>::<%==SIM:Element.Name==%> (<%==SIM:ForEach:Destructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>
<%==SIM:Destructor.SourceCodeBody==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%><%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:If:Documentation==%><%==SIM:If:Element.HasDocumentation==%>
/**<%==SIM:ForEach:Element.DocumentationLines==%><%==SIM:Line==%>
 *<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>*/<%==SIM:Line==%><%==SIM:Line==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:ForEach:Element.Operations==%>
<%==SIM:If:Documentation==%><%==SIM:If:Or(Operation.HasDocumentation,Operation.HasNestedDocumentation)==%>
/**<%==SIM:ForEach:Operation.DocumentationLines==%><%==SIM:Line==%>
 *<%==SIM:DocumentationLine==%><%==SIM:EndFor==%><%==SIM:Line==%><%==SIM:ForEach:Operation.Parameters==%>
 * @param <%==SIM:Parameter.Name==%> <%==SIM:ToSingleLine(Parameter.Documentation)==%><%==SIM:Line==%>
<%==SIM:EndFor==%> */ <%==SIM:Line==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:ReturnTypeTemplate(Operation)==%> <%==SIM:IfNot:IsBlank(Element.Namespace)==%><%==SIM:Element.Namespace("::")==%>::<%==SIM:EndIf==%><%==SIM:Element.Name==%>::<%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>
    <%==SIM:Operation.SourceCodeBody==%>
            
<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
