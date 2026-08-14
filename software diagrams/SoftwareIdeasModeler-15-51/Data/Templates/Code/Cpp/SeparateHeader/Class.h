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

<%==SIM:Template:TypeTemplate(Typable)==%>
<%==SIM:If:Or(Typable.IsArray,Typable.ReturnIsArray)==%>
<%==SIM:If:Typable.IsUnique==%><%==SIM:If:Typable.IsOrdered==%>set<<%==SIM:Typable.Type==%>> <%==SIM:Typable.Name==%><%==SIM:Else==%>unordered_set<<%==SIM:Typable.Type==%>> <%==SIM:Typable.Name==%><%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:If:Typable.IsOrdered==%><%==SIM:If:Or(Eq(ArrayType,"Array"), IsEmpty(ArrayType))==%><%==SIM:Typable.Type==%> <%==SIM:Typable.Name==%>[]<%==SIM:Else==%><%==SIM:ArrayType==%><<%==SIM:Typable.Type==%>> <%==SIM:Typable.Name==%><%==SIM:EndIf==%>
<%==SIM:Else==%><%==SIM:Typable.Type==%> <%==SIM:Typable.Name==%>[]<%==SIM:EndIf==%>
<%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:Typable.Type==%> <%==SIM:Typable.Name==%>
<%==SIM:EndIf==%>
<%==SIM:EndTemplate==%>
  
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
<%==SIM:Line==%>

<%==SIM:IfNot:IsBlank(Element.Namespace)==%>
namespace <%==SIM:Element.Namespace("::")==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>
<%==SIM:EndIf==%>

<%==SIM:If:Documentation==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
//<%==SIM:DocumentationLine==%>
<%==SIM:Line==%>
<%==SIM:EndFor==%><%==SIM:EndIf==%>
class <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClass==%> : <%==SIM:ForEach:Element.OutRelations.FilterByType(generalization)==%> <%==SIM:Relation.Visibility==%> <%==SIM:Relation.To.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:Line==%>
{<%==SIM:Line==%>
<%==SIM:IfNot:And(Equals(Element.AllAttributes.FilterByVisibility(undefined).Count,0),Equals(Element.AllOperations.FilterByVisibility(undefined).Count,0))==%>
<%==SIM:ForEach:Element.AllAttributes.FilterByVisibility(undefined)==%>
    <%==SIM:If:Attribute.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:TypeTemplate(Attribute)==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.Constructors.FilterByVisibility(undefined)==%>
	<%==SIM:Element.Name==%> (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Destructors.FilterByVisibility(undefined)==%>
	<%==SIM:Element.Name==%> (<%==SIM:ForEach:Destructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations.FilterByVisibility(undefined)==%>
    <%==SIM:If:Operation.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual <%==SIM:EndIf==%><%==SIM:ReturnTypeTemplate(Operation)==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Or(Operation.IsAbstract)==%> = 0<%==SIM:EndIf==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:EndIf==%>
<%==SIM:IfNot:And(Equals(Element.AllAttributes.FilterByVisibility(private).Count,0),Equals(Element.AllOperations.FilterByVisibility(private).Count,0))==%>
    private:<%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes.FilterByVisibility(private)==%>
        <%==SIM:If:Attribute.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:TypeTemplate(Attribute)==%> <%==SIM:Attribute.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Constructors.FilterByVisibility(private)==%>
		<%==SIM:If:Constructor.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Element.Name==%> (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Destructors.FilterByVisibility(private)==%>
		<%==SIM:If:Destructor.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Element.Name==%> (<%==SIM:ForEach:Destructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations.FilterByVisibility(private)==%>
        <%==SIM:If:Operation.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual <%==SIM:EndIf==%><%==SIM:ReturnTypeTemplate(Operation)==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Or(Operation.IsAbstract)==%> = 0<%==SIM:EndIf==%><%==SIM:If:Or(Operation.IsAbstract)==%> = 0<%==SIM:EndIf==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:IfNot:And(Equals(Element.AllAttributes.FilterByVisibility(protected).Count,0),Equals(Element.AllOperations.FilterByVisibility(protected).Count,0))==%>
    protected:<%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes.FilterByVisibility(protected)==%>
        <%==SIM:If:Attribute.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:TypeTemplate(Attribute)==%> <%==SIM:Attribute.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Constructors.FilterByVisibility(protected)==%>
		<%==SIM:If:Constructor.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Element.Name==%> (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Destructors.FilterByVisibility(protected)==%>
		<%==SIM:If:Destructor.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Element.Name==%> (<%==SIM:ForEach:Destructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations.FilterByVisibility(protected)==%>
        <%==SIM:If:Operation.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual <%==SIM:EndIf==%><%==SIM:ReturnTypeTemplate(Operation)==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Or(Operation.IsAbstract)==%> = 0<%==SIM:EndIf==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%><%==SIM:Line==%>

<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:IfNot:And(Equals(Element.AllAttributes.FilterByVisibility(internal,public).Count,0),Equals(Element.AllOperations.FilterByVisibility(internal,public).Count,0))==%>
    public:<%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes.FilterByVisibility(internal,public)==%>
        <%==SIM:If:Attribute.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:TypeTemplate(Attribute)==%> <%==SIM:Attribute.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Constructors.FilterByVisibility(internal,public)==%>
		<%==SIM:If:Constructor.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Element.Name==%> (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Destructors.FilterByVisibility(internal,public)==%>
		<%==SIM:If:Destructor.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:Element.Name==%> (<%==SIM:ForEach:Destructor.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.Operations.FilterByVisibility(internal,public)==%>
        <%==SIM:If:Operation.IsStatic==%> static <%==SIM:EndIf==%><%==SIM:If:Or(Operation.IsVirtual,Operation.IsAbstract)==%> virtual <%==SIM:EndIf==%><%==SIM:ReturnTypeTemplate(Operation)==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:ParameterTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Or(Operation.IsAbstract)==%> = 0<%==SIM:EndIf==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Line==%>
<%==SIM:EndIf==%>
};<%==SIM:Line==%>

<%==SIM:IfNot:IsBlank(Element.Namespace)==%>
<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%> 
<%==SIM:EndIf==%>