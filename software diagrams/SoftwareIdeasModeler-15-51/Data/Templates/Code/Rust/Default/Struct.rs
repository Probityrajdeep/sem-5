<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:IfNot:Element.IsContained==%>

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
<%==SIM:ForEach:Element.TaggedValues("Import")==%>
	use <%==SIM:TaggedValue.Value==%>;
	<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
	//<%==SIM:DocumentationLine==%>
	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Element.Visibility==%> struct <%==SIM:Element.Name==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.NestedClasses==%>
        <%==SIM:Include(NestedClass.java,NestedClass,False)==%>
    <%==SIM:EndFor==%>

	<%==SIM:ForEach:Element.AllAttributes==%>
		<%==SIM:ForEach:Attribute.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		<%==SIM:Attribute.Visibility==%> <%==SIM:Attribute.Name==%>: <%==SIM:TypeTemplate(Attribute)==%>
		<%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
	<%==SIM:EndFor==%>	
<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>

<%==SIM:If:Element.HasOperations==%>
impl <%==SIM:Element.Name==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>
	<%==SIM:ForEach:Element.Operations==%>
		<%==SIM:Line==%>
		<%==SIM:ForEach:Operation.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		
		<%==SIM:Operation.Visibility==%> fn <%==SIM:Operation.Name==%>(<%==SIM:IfNot:Operation.IsStatic==%>&self<%==SIM:If:Operation.HasParameters==%>, <%==SIM:EndIf==%><%==SIM:EndIf==%><%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%>: <%==SIM:TypeTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.HasReturnType==%> -> <%==SIM:TypeTemplate(Operation)==%><%==SIM:EndIf==%>
		<%==SIM:Line==%>
		{<%==SIM:StartBlock==%><%==SIM:Line==%>
			<%==SIM:Operation.SourceCodeBody==%>
		<%==SIM:EndBlock==%><%==SIM:Line==%>
        }
		<%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

	<%==SIM:EndFor==%>
	<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
<%==SIM:EndIf==%>

<%==SIM:ForEach:Element.Interfaces==%>
	impl <%==SIM:Interface.Name==%> for <%==SIM:Element.Name==%>
	{<%==SIM:StartBlock==%><%==SIM:Line==%>
		<%==SIM:ForEach:Interface.Operations==%>
			<%==SIM:Line==%>			
			fn <%==SIM:Operation.Name==%>(<%==SIM:IfNot:Operation.IsStatic==%>&self<%==SIM:If:Operation.HasParameters==%>, <%==SIM:EndIf==%><%==SIM:EndIf==%><%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%>: <%==SIM:TypeTemplate(Parameter)==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.HasReturnType==%> -> <%==SIM:TypeTemplate(Operation)==%><%==SIM:EndIf==%>
			<%==SIM:Line==%>
			{<%==SIM:StartBlock==%><%==SIM:Line==%>
				<%==SIM:Operation.SourceCodeBody==%>
			<%==SIM:EndBlock==%><%==SIM:Line==%>
			}
			<%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

		<%==SIM:EndFor==%>	
	<%==SIM:EndBlock==%><%==SIM:Line==%>
	}<%==SIM:Line==%>
<%==SIM:EndFor==%>


<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>


<%==SIM:EndIf==%>