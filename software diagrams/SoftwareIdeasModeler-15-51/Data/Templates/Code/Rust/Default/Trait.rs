<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private= ==%><%==SIM:Set:protected= ==%><%==SIM:Set:package= ==%><%==SIM:Set:public=pub==%>

<%==SIM:Template:TypeTemplate(Typable)==%>
<%==SIM:If:Typable.IsArray==%>Vec<<%==SIM:EndIf==%><%==SIM:IfNot:Typable.HasUndefinedType==%><%==SIM:Typable.Type==%><%==SIM:Else==%>Box<dyn std::any::Any><%==SIM:EndIf==%><%==SIM:If:Typable.IsArray==%>><%==SIM:EndIf==%>
<%==SIM:EndTemplate==%>

mod <%==SIM:Element.Namespace==%> <%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Imports==%>
	use <%==SIM:Import.Name==%>;
	<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
	//<%==SIM:DocumentationLine==%>
	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Element.Visibility==%> trait <%==SIM:Element.Name==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

	<%==SIM:ForEach:Element.Operations==%>
		<%==SIM:Line==%>
		<%==SIM:ForEach:Operation.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		
		fn <%==SIM:Operation.Name==%>(<%==SIM:IfNot:Operation.IsStatic==%>&self<%==SIM:If:Operation.HasParameters==%>, <%==SIM:EndIf==%><%==SIM:EndIf==%><%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%>: <%==SIM:TypeTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.HasReturnType==%> -> <%==SIM:TypeTemplate(Operation)==%><%==SIM:EndIf==%>;
		
		<%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

	<%==SIM:EndFor==%>	

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>

	<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
<%==SIM:EndIf==%>