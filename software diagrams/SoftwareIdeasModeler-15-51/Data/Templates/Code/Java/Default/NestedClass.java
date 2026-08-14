<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package= ==%><%==SIM:Set:public=public==%>

<%==SIM:ForEach:Element.DocumentationLines==%>
	//<%==SIM:DocumentationLine==%>
	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Element.Visibility==%><%==SIM:IfNot:IsEmpty(Element.Visibility)==%> <%==SIM:EndIf==%><%==SIM:If:Element.IsStatic==%>static <%==SIM:EndIf==%>class <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClass==%> extends <%==SIM:Element.SuperClass.Name==%><%==SIM:EndIf==%><%==SIM:If:Element.HasInterfaces==%> implements <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>
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
		<%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%> <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
		<%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
	<%==SIM:EndFor==%>

	<%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>
    
  <%==SIM:ForEach:Element.Constructors==%>            
      <%==SIM:Line==%>
      <%==SIM:ForEach:Operation.DocumentationLines==%>
      //<%==SIM:DocumentationLine==%>
      <%==SIM:Line==%>
      <%==SIM:EndFor==%>

      <%==SIM:Constructor.Visibility==%><%==SIM:If:Constructor.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:And(Not(Constructor.IsVirtual),Not(Constructor.IsStatic),Not(Constructor.IsAbstract))==%> final<%==SIM:EndIf==%> <%==SIM:Element.Name==%> (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
      <%==SIM:Line==%>
                               
          {<%==SIM:StartBlock==%><%==SIM:Line==%>
              <%==SIM:Constructor.SourceCodeBody==%>
            
          <%==SIM:EndBlock==%><%==SIM:Line==%>
          }
          <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
    
  <%==SIM:EndFor==%>
  <%==SIM:Line(1)==%>    
    

	<%==SIM:ForEach:Element.Operations==%>
		<%==SIM:Line==%>
		<%==SIM:ForEach:Operation.DocumentationLines==%>
			//<%==SIM:DocumentationLine==%>
			<%==SIM:Line==%>
		<%==SIM:EndFor==%>
		
		<%==SIM:If:Operation.IsOverride==%>@Override<%==SIM:EndIf==%><%==SIM:Line==%>
    <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:And(Not(Operation.IsVirtual),Not(Operation.IsStatic),Not(Operation.IsAbstract))==%> final<%==SIM:EndIf==%><%==SIM:If:Operation.IsAbstract==%> abstract<%==SIM:EndIf==%> <%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.IsAbstract==%>;<%==SIM:EndIf==%>
    <%==SIM:Line==%>
      
    <%==SIM:IfNot:Operation.IsAbstract==%>
		{<%==SIM:StartBlock==%><%==SIM:Line==%>
			<%==SIM:Operation.SourceCodeBody==%>
		<%==SIM:EndBlock==%><%==SIM:Line==%>
        }
    <%==SIM:EndIf==%>
		<%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

	<%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>


<%==SIM:Line(2)==%>

